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
            IDistrictRepository districtRepository, ICustomerLookupService customerLookupService)
        {
            _customerAddressRepository = customerAddressRepository;
            _addressRepository = addressRepository;
            _countryRepository = countryRepository;
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _districtRepository = districtRepository;
            _customerLookupService = customerLookupService;
        }

        public async Task<PagedResultDto<CustomerAddressOutputDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            if (!CurrentUser.Id.HasValue)
            {
                return null;
            }

            var customer = await _customerLookupService.GetByIdAsync(CurrentUser.Id.Value);
            var customerAddresses = await _customerAddressRepository.ListByCustomerId(CurrentUser.Id.Value);

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

                select new CustomerAddressOutputDto
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
            
            return new PagedResultDto<CustomerAddressOutputDto>(output.Count, output);
        }

        public async Task<CustomerAddressOutputDto> CreateAsync(CustomerAddressCreateDto input)
        {
            var address = await _addressRepository.InsertAsync(new Address(
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
            
            var customer = await _customerLookupService.GetByIdAsync((Guid)CurrentUser.Id);

            await _customerAddressRepository.InsertAsync(new CustomerAddress(customer.Id, address.Id, input.AddressType));

            var country = await _countryRepository.GetAsync(address.CountryId);

            return new CustomerAddressOutputDto
            {
                Address = ObjectMapper.Map<Address, CustomerAddressDto>(address),
                CountryName = country.Name,
                StateOrProvinceName = _stateOrProvinceRepository.Get(address.StateOrProvinceId).Name,
                DistrictName = address.DistrictId == null ? "" : _districtRepository.Get(address.DistrictId.Value).Name,
                DisplayCity = country.IsCityEnabled,
                DisplayDistrict = country.IsDistrictEnabled,
                DisplayZipCode = country.IsZipCodeEnabled,
                IsDefaultShippingAddress = customer.DefaultShippingAddressId == address.Id
            };
        }

        public async Task SetAsDefault(Guid id)
        {
            var address = await _addressRepository.GetAsync(id);
            if (address != null)
            {
                var customer = await _customerLookupService.GetByIdAsync((Guid)CurrentUser.Id);

                customer.DefaultShippingAddressId = id;

                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _addressRepository.DeleteAsync(id);
        }
    }
}