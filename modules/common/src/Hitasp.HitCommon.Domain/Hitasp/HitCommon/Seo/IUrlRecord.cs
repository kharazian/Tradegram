using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Seo
{
    public interface IUrlRecord : IAggregateRoot<Guid>
    {
        Guid EntityId { get; }
        
        string EntityName { get; }
        
        string Slug { get; }
        
        bool IsActive { get; }
    }
}