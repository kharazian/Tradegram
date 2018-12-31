using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Addresses.Dtos;
using Hitasp.HitCommerce.Customers;
using Hitasp.HitCommerce.Directions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Hitasp.HitCommerce.Addresses
{
    public class AddressAppService : ApplicationService, IAddressAppService
    {
        protected ICustomerLookupService CustomerLookupService { get; }
        
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateOrProvinceRepository _stateOrProvinceRepository;
        private readonly IDistrictRepository _districtRepository;

        public AddressAppService(
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
            
            CustomerLookupService = customerLookupService;
        }

        public async Task<ListResultDto<AddressForViewDto>> GetListAsync(AddressGetAllDto input)
        {
            var customer = await CustomerLookupService.GetByIdAsync(input.CustomerId);

            if (customer == null)
            {
                return null;
            }
            
            var addressTypeFilter = (AddressType)input.AddressType;
            
            var customerAddresses = await _customerAddressRepository.ListByCustomerId(customer.Id);
            
            var filteredCustomerAddress = customerAddresses.WhereIf(input.AddressType > -1, e => e.AddressType == addressTypeFilter);

            var query = from customerAddress in filteredCustomerAddress

                join address in _addressRepository.GetList() on customerAddress.AddressId
                    equals address.Id into joinedAddress
                from userAddress in joinedAddress.DefaultIfEmpty()
                join country in _countryRepository.GetList() on userAddress.CountryId
                    equals country.Id into joinedCountry
                from addressCountry in joinedCountry.DefaultIfEmpty()
                join stateOrProvince in _stateOrProvinceRepository.GetList() on userAddress.StateOrProvinceId
                    equals stateOrProvince.Id into joinedStates
                from addressState in joinedStates.DefaultIfEmpty()
                join district in _districtRepository.GetList() on userAddress.DistrictId
                    equals district.Id into joinedDistrict
                from addressDistrict in joinedStates.DefaultIfEmpty()

                select new AddressForViewDto
                {
                    Address = ObjectMapper.Map<Address, AddressDto>(userAddress),
                    CountryName = addressCountry.Name,
                    StateOrProvinceName = addressState.Name,
                    DistrictName = addressDistrict.Name,
                    DisplayCity = addressCountry.IsCityEnabled,
                    DisplayDistrict = addressCountry.IsDistrictEnabled,
                    DisplayZipCode = addressCountry.IsZipCodeEnabled,
                    IsDefaultShippingAddress = customer.DefaultShippingAddressId == userAddress.Id
                };

            var output = query.ToList();

            return new ListResultDto<AddressForViewDto>(output);
        }

        public async Task<AddressForEditDto> GetForEditAsync(Guid id)
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

            var customer = await CustomerLookupService.FindByIdAsync(customerAddress.CustomerId);
            var address = await _addressRepository.GetAsync(customerAddress.AddressId);
            var country = await _countryRepository.GetAsync(address.CountryId);
            var stateOrProvince = await _stateOrProvinceRepository.GetAsync(address.StateOrProvinceId);

            var output = new AddressForEditDto
            {
                Address = ObjectMapper.Map<Address, AddressCreateOrEditDto>(address),
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

        public async Task<AddressForViewDto> CreateOrEditAsync(AddressCreateOrEditDto input)
        {
            var customer = await CustomerLookupService.GetByIdAsync((Guid) CurrentUser.Id);

            if (customer == null)
            {
                return null;
            }
            
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

            customer.SetAddress(address.Id, input.AddressType);

            await CurrentUnitOfWork.SaveChangesAsync();
            
            var country = await _countryRepository.GetAsync(address.CountryId);
            var stateOrProvince = await _stateOrProvinceRepository.GetAsync(address.StateOrProvinceId);

            return new AddressForViewDto
            {
                Address = ObjectMapper.Map<Address, AddressDto>(address),
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
                var customer = await CustomerLookupService.GetByIdAsync(customerAddress.CustomerId);

                switch (customerAddress.AddressType)
                {
                    case AddressType.Billing:
                        customer.SetDefaultBillingAddress(address.Id);
                        break;
                    
                    case AddressType.Shipping:
                        customer.SetDefaultShippingAddress(address.Id);
                        break;
                    
                    default:
                        customer.SetDefaultShippingAddress(address.Id);
                        break;
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