using System;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Aggregates;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions
{
    public static class BackInStockSubscriptionsDbContextModelCreatingExtensions
    {
        public static void ConfigureBackInStockSubscriptions(
            this ModelBuilder builder,
            Action<CatalogModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<BackInStockSubscription>(b =>
            {
                b.ToTable(options.TablePrefix + "BackInStockSubscriptions", options.Schema);

                b.ConfigureCreationAudited();
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.ProductId);
                
                b.Property(x => x.ProductId).HasColumnName(nameof(BackInStockSubscription.ProductId));
                b.Property(x => x.CustomerId).HasColumnName(nameof(BackInStockSubscription.CustomerId));
            });
        }
    }
}