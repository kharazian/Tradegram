using System;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Directions.Dtos;

namespace Hitasp.HitCommerce.Directions
{
    public interface IStateOrProvinceAppService : IAsyncCrudAppService<StateOrProvinceDto, Guid,
        StateOrProvinceGetListInput, StateOrProvinceCreateOrEditDto, StateOrProvinceCreateOrEditDto>
    {
    }
}