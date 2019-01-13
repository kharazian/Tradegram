using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Assets
{
    public interface IAssetBaseRepository<TAsset> : IBasicRepository<TAsset, Guid>
        where TAsset : AssetBase
    {
        Task<TAsset> FindByUniqueNameAsync(string uniqueName, CancellationToken cancellationToken = default);
    }
}