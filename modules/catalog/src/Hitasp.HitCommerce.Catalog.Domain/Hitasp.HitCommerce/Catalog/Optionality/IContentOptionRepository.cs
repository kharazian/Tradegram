using System;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Optionality
{
    //TODO: Move to common module
    public interface IContentOptionRepository: IBasicRepository<ContentOption, Guid>
    {
        
    }
}