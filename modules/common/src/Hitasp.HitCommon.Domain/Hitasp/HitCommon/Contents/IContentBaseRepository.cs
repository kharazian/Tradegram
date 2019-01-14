using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Contents
{
    public interface IContentBaseRepository<TContent> : IRepository<TContent, Guid>
        where TContent : ContentBase
    {
        Task<TContent> FindByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}