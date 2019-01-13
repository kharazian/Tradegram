using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Contents
{
    public interface IContentAttributeRepository : IBasicRepository<ContentAttribute, Guid>
    {
        Task<List<ContentAttribute>> GetListAsync(Guid attributeGroupId, CancellationToken cancellationToken = default);
        
        Task<ContentAttribute> FindByNameAsync(Guid attributeGroupId, string name, CancellationToken cancellationToken = default);
    }
}