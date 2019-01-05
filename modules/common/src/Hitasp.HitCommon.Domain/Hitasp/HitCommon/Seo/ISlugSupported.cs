using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Seo
{
    public interface ISlugSupported : IAggregateRoot<Guid>
    {
        [Required]
        string Name { get; }

        [Required]
        string Slug  { get; }
    }
}