using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Assets
{
    public interface IAssetBaseRepository<TAsset> : IRepository<TAsset, Guid>
        where TAsset : Asset
    {
        Task<TAsset> FindByUniqueNameAsync(string uniqueName, CancellationToken cancellationToken = default);
    }
}