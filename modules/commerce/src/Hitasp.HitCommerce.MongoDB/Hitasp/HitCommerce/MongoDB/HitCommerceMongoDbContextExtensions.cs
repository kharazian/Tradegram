using System;
using Volo.Abp;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Customers;
using Hitasp.HitCommerce.Directions;
using Hitasp.HitCommerce.Medias;
using Hitasp.HitCommerce.Seo;
using Hitasp.HitCommerce.UserGroups;
using Hitasp.HitCommerce.Vendors;
using Hitasp.HitCommerce.Widgets;

namespace Hitasp.HitCommerce.MongoDB
{
    public static class HitCommerceMongoDbContextExtensions
    {
        public static void ConfigureHitCommerce(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HitCommerceMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);
            
            builder.Entity<Customer>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Users";
            });
            
            builder.Entity<UserGroup>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "UserGroups";
            });

            builder.Entity<CustomerUserGroup>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "CustomerUserGroups";
            });

            builder.Entity<UrlRecord>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "UrlRecords";
            });

            builder.Entity<Address>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Addresses";
            });

            builder.Entity<Country>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Countries";
            });
            
            builder.Entity<StateOrProvince>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "StateOrProvinces";
            });
            
            builder.Entity<District>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Districts";
            });
            
            builder.Entity<Media>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Medias";
            });
                        
            builder.Entity<Vendor>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Vendors";
            });
            
            builder.Entity<Widget>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Widgets";
            });
            
            builder.Entity<WidgetZone>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "WidgetZones";
            });
            
            builder.Entity<WidgetInstance>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "WidgetInstances";
            });
        }
    }
}