using System;
using Hitasp.HitCommerce.Directions.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Directions
{
    public class StateOrProvinceAppService : AsyncCrudAppService<StateOrProvince, StateOrProvinceDto, Guid,
        StateOrProvinceGetListInput, StateOrProvinceCreateOrEditDto, StateOrProvinceCreateOrEditDto>,
        IStateOrProvinceAppService
    {
        public StateOrProvinceAppService(IStateOrProvinceRepository repository) : base(repository)
        {
        }

        //TODO: override GetListAsync to filter output by input options 
    }
}