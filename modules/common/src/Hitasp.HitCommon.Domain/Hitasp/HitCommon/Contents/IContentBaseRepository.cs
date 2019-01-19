using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Contents
{
    public interface IContentBaseRepository<TContent> : IRepository<TContent, Guid>
        where TContent : Content
    {
        Task<TContent> FindByTitleAsync(string title, CancellationToken cancellationToken = default);
    }
}