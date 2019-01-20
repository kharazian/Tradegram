using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Assets
{
    public interface IAssetBaseRepository<TAsset> : IRepository<TAsset, Guid>
        where TAsset : Asset
    {
        Task<TAsset> FindByUniqueNameAsync(string uniqueName, CancellationToken cancellationToken = default);
        
        Task<List<TAsset>> GetListAsync(Guid spaceId, bool includeDetails = false,
            CancellationToken cancellationToken = default);

        List<TAsset> GetList(Guid spaceId, bool includeDetails = false);
    }
}