using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Manufacturers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Manufacturers
{
    public interface IManufacturerAppService : IAsyncCrudAppService<ManufacturerDto, Guid,
        ManufacturerGetListInput, ManufacturerCreateOrUpdateDto>
    {
        Task<ListResultDto<ManufacturerDto>> GetListFilteredAsync(bool showHidden = false);

        Task<ListResultDto<ManufacturerDto>> GetListByIdsAsync(Guid[] manufacturerIds);

        Task<string[]> GetNotExistingCategoriesAsync(string[] manufacturerIdsNames);
    }
}