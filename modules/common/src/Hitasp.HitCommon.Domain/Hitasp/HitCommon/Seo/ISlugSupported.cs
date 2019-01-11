using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Seo
{
    public interface ISlugSupported : IAggregateRoot<Guid>
    {
        string Name { get; }

        string Slug  { get; }

        void SetName([NotNull] string name);

        void SetSlug([NotNull] string slug);
    }
}