using System;

namespace Hitasp.HitCommon.Seo
{
    public interface ISeoData
    {
        Guid Id { get; }

        Guid EntityId { get; }
        
        string EntityName { get; }

        string Slug { get; }

        bool IsActive { get; set; }
    }
}