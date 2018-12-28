using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Seo
{
    public interface IUrlRecordRepositoryBase<TUrlRecord> : IBasicRepository<TUrlRecord, Guid>
        where TUrlRecord : class, IUrlRecord, IAggregateRoot<Guid>
    {
        Task<TUrlRecord> FindBySlugAsync(string slug, CancellationToken cancellationToken = default);
    }
}