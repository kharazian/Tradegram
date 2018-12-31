using System;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Addresses.Dtos;
using Hitasp.HitCommerce.Directions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Addresses
{
    public class AddressAppService : ApplicationService, IAddressAppService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateOrProvinceRepository _stateOrProvinceRepository;
        private readonly IDistrictRepository _districtRepository;

        public AddressAppService(
            IAddressRepository addressRepository,
            ICountryRepository countryRepository,
            IStateOrProvinceRepository stateOrProvinceRepository,
            IDistrictRepository districtRepository
            )
        {
            _addressRepository = addressRepository;
            _countryRepository = countryRepository;
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _districtRepository = districtRepository;
        }

        public async Task<PagedResultDto<AddressWithDetailDto>> GetListAsync(AddressGetListInput input)
        {
            var addresses = await _addressRepository.GetListAsync();

            var query = from address in addresses
                join country in _countryRepository.GetList() on address.CountryId
                    equals country.Id into joinedCountry
                from addressCountry in joinedCountry.DefaultIfEmpty()
                join stateOrProvince in _stateOrProvinceRepository.GetList() on address.StateOrProvinceId
                    equals stateOrProvince.Id into joinedStates
                from addressState in joinedStates.DefaultIfEmpty()
                join district in _districtRepository.GetList() on address.DistrictId
                    equals district.Id into joinedDistrict
                from addressDistrict in joinedStates.DefaultIfEmpty()

                select new AddressWithDetailDto
                {
                    Address = ObjectMapper.Map<Address, AddressDto>(address),
                    CountryName = addressCountry.Name,
                    StateOrProvinceName = addressState.Name,
                    DistrictName = addressDistrict.Name,
                    DisplayCity = addressCountry.IsCityEnabled,
                    DisplayDistrict = addressCountry.IsDistrictEnabled,
                    DisplayZipCode = addressCountry.IsZipCodeEnabled
                };

            var output = query.ToList();

            var totalCount = output.LongCount();

            return new PagedResultDto<AddressWithDetailDto>(totalCount, output);
        }

        public async Task<AddressForEditOutput> GetForEditAsync(Guid addressId)
        {
            var address = await _addressRepository.GetAsync(addressId);

            var country = await _countryRepository.GetAsync(address.CountryId);
            
            var stateOrProvince = await _stateOrProvinceRepository.GetAsync(address.StateOrProvinceId);

            var output = new AddressForEditOutput
            {
                Address = ObjectMapper.Map<Address, AddressCreateOrEditDto>(address),
                CountryName = country.Name,
                StateOrProvinceName = stateOrProvince.Name,
                DisplayCity = country.IsCityEnabled,
                DisplayDistrict = country.IsDistrictEnabled,
                DisplayZipCode = country.IsZipCodeEnabled,
                DistrictName = address.DistrictId.HasValue
                    ? ""
                    : (await _districtRepository.GetAsync(address.DistrictId.Value)).Name
            };

            return output;
        }

        public async Task<AddressWithDetailDto> CreateOrEditAsync(AddressCreateOrEditDto input)
        {
            Address address;
            
            if (input.Id == null)
            {
                address = await Create(input);
            }
            else
            {
                address = await Update(input);
            }
            
            
            var country = await _countryRepository.GetAsync(address.CountryId);
            
            var stateOrProvince = await _stateOrProvinceRepository.GetAsync(address.StateOrProvinceId);

            return new AddressWithDetailDto
            {
                Address = ObjectMapper.Map<Address, AddressDto>(address),
                CountryName = country.Name,
                StateOrProvinceName = stateOrProvince.Name,
                DisplayCity = country.IsCityEnabled,
                DisplayDistrict = country.IsDistrictEnabled,
                DisplayZipCode = country.IsZipCodeEnabled,
                DistrictName = address.DistrictId.HasValue
                    ? ""
                    : (await _districtRepository.GetAsync(address.DistrictId.Value)).Name
            };
        }

        public async Task DeleteAsync(Guid addressId)
        {
            await _addressRepository.DeleteAsync(addressId);
        }

        public async Task<AddressReportRequestOutput> GetAddressTotalByCountryId(Guid countryId)
        {
            return new AddressReportRequestOutput
            {
                TotalAddress = await _addressRepository.GetAddressTotalByCountryId(countryId)
            };
        }

        public async Task<AddressReportRequestOutput> GetAddressTotalByStateOrProvinceId(Guid stateOrProvinceId)
        {
            return new AddressReportRequestOutput
            {
                TotalAddress = await _addressRepository.GetAddressTotalByStateOrProvinceId(stateOrProvinceId)
            };
        }

        public async Task<AddressReportRequestOutput> GetAddressTotalByDistrictId(Guid districtId)
        {
            return new AddressReportRequestOutput
            {
                TotalAddress = await _addressRepository.GetAddressTotalByDistrictId(districtId)
            };
        }

        private async Task<Address> Create(AddressCreateOrEditDto input)
        {
            var address = new Address(
                GuidGenerator.Create(),
                input.Phone,
                input.AddressLine1,
                input.AddressLine2,
                input.City,
                input.ZipCode,
                input.CountryId,
                input.StateOrProvinceId,
                input.DistrictId
            );

            address.SetNewLine(
                input.Phone,
                input.AddressLine1,
                input.AddressLine2,
                input.City,
                input.ZipCode
                );

            return await _addressRepository.InsertAsync(address);
        }

        private async Task<Address> Update(AddressCreateOrEditDto input)
        {
            var address = await _addressRepository.GetAsync((Guid) input.Id);

            address.SetNewLine(
                input.Phone,
                input.AddressLine1,
                input.AddressLine2,
                input.City,
                input.ZipCode
            );
            
            address.SetNewDirection(
                input.CountryId,
                input.StateOrProvinceId,
                input.DistrictId
                );

            return await _addressRepository.UpdateAsync(address);
        }
    }
}