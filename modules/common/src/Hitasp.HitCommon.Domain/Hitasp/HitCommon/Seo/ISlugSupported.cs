using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Seo
{
    public interface ISlugSupported : IAggregateRoot<Guid>
    {
        [Required]
        string Name { get; }

        [Required]
        string Slug  { get; }

        void SetName([NotNull] string name);

        void SetSlug([NotNull] string slug);
    }
}