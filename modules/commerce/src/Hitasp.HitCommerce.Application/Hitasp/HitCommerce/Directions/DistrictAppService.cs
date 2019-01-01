using System;
using Hitasp.HitCommerce.Directions.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Directions
{
    public class DistrictAppService : AsyncCrudAppService<District, DistrictDto, Guid,
        DistrictGetListInput, DistrictCreateOrEditDto, DistrictCreateOrEditDto>, IDistrictAppService
    {
        public DistrictAppService(IDistrictRepository repository) : base(repository)
        {
        }

        //TODO: override GetListAsync to filter output by input options 
    }
}