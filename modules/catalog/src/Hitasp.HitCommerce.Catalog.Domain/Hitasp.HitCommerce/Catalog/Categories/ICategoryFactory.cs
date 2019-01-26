using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public interface ICategoryFactory : IDomainService
    {
        Task<Category> CreateCategoryAsync(Guid categoryTemplateId,[NotNull] string name, [NotNull] string title);
    }
}