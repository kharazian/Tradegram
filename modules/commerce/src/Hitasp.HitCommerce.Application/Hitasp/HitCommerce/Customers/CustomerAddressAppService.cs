using System;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Customers.Dtos;
using Hitasp.HitCommerce.Directions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Customers
{
    public class CustomerAddressAppService : ApplicationService, ICustomerAddressAppService
    {
        protected ICustomerLookupService UserLookupService { get; }
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateOrProvinceRepository _stateOrProvinceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerAddressAppService(
            IAddressRepository addressRepository,
            ICustomerAddressRepository customerAddressRepository, 
            ICustomerLookupService userLookupService, 
            ICountryRepository countryRepository,
            IStateOrProvinceRepository stateOrProvinceRepository,
            IDistrictRepository districtRepository, 
            ICustomerRepository customerRepository)
        {
            UserLookupService = userLookupService;
            
            _addressRepository = addressRepository;
            _customerAddressRepository = customerAddressRepository;
            _countryRepository = countryRepository;
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _districtRepository = districtRepository;
            _customerRepository = customerRepository;
        }

        public async Task<ListResultDto<CustomerAddressDto>> GetListAsync(Guid customerId)
        {
            var customer = await UserLookupService.FindByIdAsync(customerId);

            if (customer == null)
            {
                return null;
            }
            
            var customerAddresses = await _customerAddressRepository.ListByCustomerId(customerId);

            var query = from customerAddress in customerAddresses
                
                        join address in _addressRepository.GetList() on customerAddress.AddressId
                            equals address.Id into joinedAddress
                        from userAddress in joinedAddress.DefaultIfEmpty()
                
                        join country in _countryRepository.GetList() on userAddress.CountryId
                            equals country.Id
                        join stateOrProvince in _stateOrProvinceRepository.GetList() on userAddress.StateOrProvinceId
                            equals stateOrProvince.Id 
                        join district in _districtRepository.GetList() on userAddress.DistrictId
                            equals district.Id
                    
                        select new CustomerAddressDto
                        {
                            CustomerId = customer.Id,
                            AddressId = userAddress.Id,
                            FullName = customer.Name + " " + customer.Surname,
                            Address = string.Format(
                                userAddress.ToString(), ", ",
                                district == null ? "" : district.Name + ", ",
                                stateOrProvince.Name, ", ",
                                country.Name),
                            AddressType = customerAddress.AddressType
                        };

            var output = query.ToList();
            
            return new ListResultDto<CustomerAddressDto>(output);
        }

        public async Task<CustomerAddressDto> GetAsync(Guid addressId)
        {
            var customer = await UserLookupService.FindByIdAsync((Guid)CurrentUser.Id);

            if (customer == null)
            {
                return null;
            }

            var customerAddress = (await _customerAddressRepository.ListByCustomerId(customer.Id))
                .Single(x => x.AddressId == addressId);

            if (customerAddress == null)
            {
                return null;
            }

            var address = await _addressRepository.GetAsync(customerAddress.AddressId);
            var country = await _countryRepository.GetAsync(address.CountryId);
            var stateOrProvince = await _stateOrProvinceRepository.GetAsync(address.StateOrProvinceId);

            return new CustomerAddressDto
            {
                CustomerId = customer.Id,
                AddressId = address.Id,
                FullName = customer.Name + " " + customer.Surname,
                Address = string.Format(
                    address.ToString(), ", ",
                    address.DistrictId.HasValue 
                        ? "" 
                        : (await _districtRepository.GetAsync(address.DistrictId.Value)).Name + ", ",
                    stateOrProvince.Name, ", ",
                    country.Name),
                AddressType = customerAddress.AddressType
            };
        }

        public async Task DeleteAsync(Guid addressId)
        {
            var customer = await UserLookupService.FindByIdAsync((Guid) CurrentUser.Id);
            
            if (customer == null)
            {
                return;
            }
            
            var customerAddress = (await _customerAddressRepository.ListByCustomerId(customer.Id))
                .Single(x => x.AddressId == addressId);

            if (customerAddress != null)
            {
                if (customer.DefaultBillingAddressId == customerAddress.AddressId)
                {
                    customer.SetDefaultBillingAddress(null);
                }

                if (customer.DefaultShippingAddressId == customerAddress.AddressId)
                {
                    customer.SetDefaultShippingAddress(null);
                }

                await _customerRepository.UpdateAsync(customer);
                await _addressRepository.DeleteAsync(customerAddress.AddressId);
            }
        }

        public async Task SetAsDefaultAsync(Guid addressId)
        {
            var customer = await UserLookupService.FindByIdAsync((Guid) CurrentUser.Id);
            
            if (customer == null)
            {
                return;
            }
            
            var customerAddress = (await _customerAddressRepository.ListByCustomerId(customer.Id))
                .Single(x => x.AddressId == addressId);
            
            if (customerAddress != null)
            {
                switch (customerAddress.AddressType)
                {
                    case AddressType.Billing:
                        customer.SetDefaultBillingAddress(customerAddress.AddressId);
                        break;
                    case AddressType.Shipping:
                        customer.SetDefaultShippingAddress(customerAddress.AddressId);
                        break;
                    case AddressType.Undefined:
                        throw new AbpException("AddressType Undefined");
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                await _customerRepository.UpdateAsync(customer);
            }
        }
    }
}