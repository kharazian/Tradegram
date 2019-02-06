using System;
using Hitasp.HitCommerce.Catalog.Templates.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.Templates
{
    public interface ITemplateAppService : IAsyncCrudAppService<TemplateDto, Guid,
        TemplateGetListInput, TemplateCreateOrUpdateDto>
    {
        
    }
}