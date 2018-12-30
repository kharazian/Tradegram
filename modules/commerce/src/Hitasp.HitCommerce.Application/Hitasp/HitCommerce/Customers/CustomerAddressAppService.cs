using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Customers.Dtos;
using Hitasp.HitCommerce.Directions;

namespace Hitasp.HitCommerce.Customers
{
    public class CustomerAddressAppService : ApplicationService, ICustomerAddressAppService
    {
        private readonly ICustomerLookupService _customerLookupService;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateOrProvinceRepository _stateOrProvinceRepository;
        private readonly IDistrictRepository _districtRepository;

        public CustomerAddressAppService(
            ICustomerAddressRepository customerAddressRepository,
            IAddressRepository addressRepository,
            ICountryRepository countryRepository,
            IStateOrProvinceRepository stateOrProvinceRepository,
            IDistrictRepository districtRepository, 
            ICustomerLookupService customerLookupService)
        {
            _customerAddressRepository = customerAddressRepository;
            _addressRepository = addressRepository;
            _countryRepository = countryRepository;
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _districtRepository = districtRepository;
            _customerLookupService = customerLookupService;
        }

        public async Task<PagedResultDto<CustomerAddressForViewDto>> GetListAsync(CustomerAddressGetAllDto input)
        {
            if (CurrentUser == null)
            {
                return null;
            }
            
            var customer = await _customerLookupService.GetByIdAsync((Guid)CurrentUser.Id);

            if (customer == null)
            {
                return null;
            }
            
            var customerAddresses = await _customerAddressRepository.ListByCustomerId(customer.Id);

            var query = from customerAddress in customerAddresses
                join address in _addressRepository.GetList() on customerAddress.AddressId equals address.Id into
                    joinedAddress
                from userAddress in joinedAddress.DefaultIfEmpty()
                join country in _countryRepository.GetList() on userAddress.CountryId equals country.Id into
                    joinedCountry
                from addressCountry in joinedCountry.DefaultIfEmpty()
                join stateOrProvince in _stateOrProvinceRepository.GetList() on userAddress.StateOrProvinceId equals
                    stateOrProvince.Id into joinedStates
                from addressState in joinedStates.DefaultIfEmpty()
                join district in _districtRepository.GetList() on userAddress.DistrictId equals district.Id into
                    joinedDistrict
                from addressDistrict in joinedStates.DefaultIfEmpty()
                select new CustomerAddressForViewDto
                {
                    Address = ObjectMapper.Map<Address, CustomerAddressDto>(userAddress),
                    CountryName = addressCountry.Name,
                    StateOrProvinceName = addressState.Name,
                    DistrictName = addressDistrict.Name,
                    DisplayCity = addressCountry.IsCityEnabled,
                    DisplayDistrict = addressCountry.IsDistrictEnabled,
                    DisplayZipCode = addressCountry.IsZipCodeEnabled,
                    IsDefaultShippingAddress = customer.DefaultShippingAddressId == userAddress.Id
                };

            var output = query.ToList();

            var totalCount = output.LongCount();

            return new PagedResultDto<CustomerAddressForViewDto>(totalCount, output);
        }

        public async Task<CustomerAddressForEditDto> GetForEditAsync(Guid id)
        {
            if (CurrentUser == null)
            {
                return null;
            }
            
            var customerAddress = (await _customerAddressRepository.ListByCustomerId((Guid) CurrentUser.Id))
                .FirstOrDefault(x => x.AddressId == id);

            if (customerAddress == null)
            {
                return null;
            }

            var customer = await _customerLookupService.FindByIdAsync(customerAddress.CustomerId);
            var address = await _addressRepository.GetAsync(customerAddress.AddressId);
            var country = await _countryRepository.GetAsync(address.CountryId);
            var stateOrProvince = await _stateOrProvinceRepository.GetAsync(address.StateOrProvinceId);

            var output = new CustomerAddressForEditDto
            {
                Address = ObjectMapper.Map<Address, CustomerAddressCreateOrEditDto>(address),
                CountryName = country.Name,
                StateOrProvinceName = stateOrProvince.Name,
                IsDefaultShippingAddress = customer.DefaultShippingAddressId == address.Id,
                DisplayCity = country.IsCityEnabled,
                DisplayDistrict = country.IsDistrictEnabled,
                DisplayZipCode = country.IsZipCodeEnabled,
                DistrictName = address.DistrictId.HasValue
                    ? ""
                    : (await _districtRepository.GetAsync(address.DistrictId.Value)).Name
            };

            return output;
        }

        public async Task<CustomerAddressForViewDto> CreateOrEditAsync(CustomerAddressCreateOrEditDto input)
        {
            Address address;

            if (!input.Id.HasValue)
            {
                address = await _addressRepository.InsertAsync(new Address(
                    GuidGenerator.Create(),
                    input.Phone,
                    input.AddressLine1,
                    input.AddressLine2,
                    input.City,
                    input.ZipCode,
                    input.CountryId,
                    input.StateOrProvinceId,
                    input.DistrictId
                ));
            }
            else
            {
                address = await _addressRepository.GetAsync(input.Id.Value);

                address.SetNewLine(
                    input.Phone,
                    input.AddressLine1,
                    input.AddressLine2,
                    input.City,
                    input.ZipCode);

                address.SetNewDirection(
                    input.CountryId,
                    input.StateOrProvinceId,
                    input.DistrictId
                );

                address = await _addressRepository.UpdateAsync(address);
            }

            var customer = await _customerLookupService.GetByIdAsync((Guid) CurrentUser.Id);

            customer.SetAddress(address.Id, input.AddressType);

            await CurrentUnitOfWork.SaveChangesAsync();
            
            var country = await _countryRepository.GetAsync(address.CountryId);
            var stateOrProvince = await _stateOrProvinceRepository.GetAsync(address.StateOrProvinceId);

            return new CustomerAddressForViewDto
            {
                Address = ObjectMapper.Map<Address, CustomerAddressDto>(address),
                CountryName = country.Name,
                StateOrProvinceName = stateOrProvince.Name,
                IsDefaultShippingAddress = customer.DefaultShippingAddressId == address.Id,
                DisplayCity = country.IsCityEnabled,
                DisplayDistrict = country.IsDistrictEnabled,
                DisplayZipCode = country.IsZipCodeEnabled,
                DistrictName = address.DistrictId.HasValue
                    ? ""
                    : (await _districtRepository.GetAsync(address.DistrictId.Value)).Name
            };
        }

        public async Task SetAsDefaultAsync(Guid id)
        {
            if (CurrentUser == null)
            {
                return;
            }
            
            var customerAddress = (await _customerAddressRepository.ListByCustomerId((Guid) CurrentUser.Id))
                .FirstOrDefault(x => x.AddressId == id);

            if (customerAddress == null)
            {
                return;
            }

            var address = await _addressRepository.GetAsync(customerAddress.AddressId);

            if (address != null)
            {
                var customer = await _customerLookupService.GetByIdAsync((Guid) CurrentUser.Id);

                switch (customerAddress.AddressType)
                {
                    case AddressType.Billing:
                        customer.SetDefaultBillingAddress(address.Id);

                        break;
                    case AddressType.Shipping:
                        customer.SetDefaultShippingAddress(address.Id);

                        break;
                    default:

                        throw new ArgumentOutOfRangeException();
                }

                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            if (CurrentUser == null)
            {
                return;
            }
            
            var customerAddress = (await _customerAddressRepository.ListByCustomerId((Guid) CurrentUser.Id))
                .FirstOrDefault(x => x.AddressId == id);

            if (customerAddress == null)
            {
                return;
            }

            await _customerAddressRepository.DeleteAsync(customerAddress);
        }
    }
}