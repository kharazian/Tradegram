using System;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Directions.Dtos;

namespace Hitasp.HitCommerce.Directions
{
    public interface IDistrictAppService : IAsyncCrudAppService<DistrictDto, Guid,
        DistrictGetListInput, DistrictCreateOrEditDto, DistrictCreateOrEditDto>
    {
    }
}