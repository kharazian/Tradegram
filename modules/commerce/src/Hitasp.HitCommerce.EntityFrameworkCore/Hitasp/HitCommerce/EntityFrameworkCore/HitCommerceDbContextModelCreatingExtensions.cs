using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;
using Hitasp.HitCommerce.Addresses;
using Hitasp.HitCommerce.Customers;
using Hitasp.HitCommerce.Directions;
using Hitasp.HitCommerce.UserGroups;
using Hitasp.HitCommerce.Vendors;
using Hitasp.HitCommerce.Widgets;

namespace Hitasp.HitCommerce.EntityFrameworkCore
{
    public static class HitCommerceDbContextModelCreatingExtensions
    {
        public static void ConfigureHitCommerce(
            this ModelBuilder builder,
            Action<HitCommerceModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HitCommerceModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Customer>(b =>
            {
                b.ToTable(options.TablePrefix + "Users", options.Schema);

                b.ConfigureAbpUser(options);
            });

            builder.Entity<UserGroup>(b =>
            {
                b.ToTable(options.TablePrefix + "UserGroups", options.Schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.Name).IsUnique();
                b.ConfigureFullAudited();


                b.Property(x => x.Name).IsRequired().HasMaxLength(UserGroupConsts.MaxNameLength).HasColumnName(nameof(UserGroup.Name));
                b.Property(x => x.Description).HasColumnName(nameof(UserGroup.Description));
                b.Property(x => x.IsActive).HasColumnName(nameof(UserGroup.IsActive));
            });

            builder.Entity<Address>(b =>
            {
                b.ToTable(options.TablePrefix + "Addresses", options.Schema);
                b.HasKey(x => x.Id);


                b.Property(x => x.Phone).HasColumnName(nameof(Address.Phone));
                b.Property(x => x.AddressLine1).IsRequired().HasColumnName(nameof(Address.AddressLine1));
                b.Property(x => x.AddressLine2).HasColumnName(nameof(Address.AddressLine2));
                b.Property(x => x.City).IsRequired().HasColumnName(nameof(Address.City));
                b.Property(x => x.ZipCode).IsRequired().HasColumnName(nameof(Address.ZipCode));
                b.Property(x => x.DistrictId).HasColumnName(nameof(Address.DistrictId));
                b.Property(x => x.StateOrProvinceId).IsRequired().HasColumnName(nameof(Address.StateOrProvinceId));
                b.Property(x => x.CountryId).IsRequired().HasColumnName(nameof(Address.CountryId));

                b.HasOne<District>().WithMany().HasForeignKey(x => x.DistrictId).OnDelete(DeleteBehavior.Restrict);
                b.HasOne<StateOrProvince>().WithMany().IsRequired().HasForeignKey(x => x.StateOrProvinceId).OnDelete(DeleteBehavior.Restrict);
                b.HasOne<Country>().WithMany().IsRequired().HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Country>(b =>
            {
                b.ToTable(options.TablePrefix + "Countries", options.Schema);
                b.HasKey(x => x.Id);
                b.HasIndex(c => c.Name).IsUnique();
                b.HasIndex(x => x.Code3).IsUnique();


                b.Property(x => x.Name).IsRequired().HasMaxLength(DirectionConsts.MaxNameLength).HasColumnName(nameof(Country.Name));
                b.Property(x => x.Code3).IsRequired().HasMaxLength(DirectionConsts.MaxCode3Length).HasColumnName(nameof(Country.Code3));
                b.Property(x => x.IsBillingEnabled).HasColumnName(nameof(Country.IsBillingEnabled));
                b.Property(x => x.IsShippingEnabled).HasColumnName(nameof(Country.IsShippingEnabled));
                b.Property(x => x.IsDistrictEnabled).HasColumnName(nameof(Country.IsDistrictEnabled));
                b.Property(x => x.IsCityEnabled).HasColumnName(nameof(Country.IsCityEnabled));
                b.Property(x => x.IsZipCodeEnabled).HasColumnName(nameof(Country.IsZipCodeEnabled));

                b.HasMany<StateOrProvince>().WithOne().HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<StateOrProvince>(b =>
            {
                b.ToTable(options.TablePrefix + "StateOrProvinces", options.Schema);
                b.HasKey(x => x.Id);


                b.Property(x => x.CountryId).HasColumnName(nameof(StateOrProvince.CountryId));
                b.Property(x => x.Name).IsRequired().HasMaxLength(DirectionConsts.MaxNameLength).HasColumnName(nameof(StateOrProvince.Name));
                b.Property(x => x.Code).HasColumnName(nameof(StateOrProvince.Code));
                b.Property(x => x.Type).HasColumnName(nameof(StateOrProvince.Type));

                b.HasOne<Country>().WithMany().IsRequired().HasForeignKey(x => x.CountryId);
                b.HasMany<District>().WithOne().HasForeignKey(x => x.StateOrProvinceId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<District>(b =>
            {
                b.ToTable(options.TablePrefix + "Districts", options.Schema);
                b.HasKey(x => x.Id);


                b.Property(x => x.StateOrProvinceId).HasColumnName(nameof(District.StateOrProvinceId));
                b.Property(x => x.Name).IsRequired().HasMaxLength(DirectionConsts.MaxNameLength).HasColumnName(nameof(District.Name));
                b.Property(x => x.Location).HasColumnName(nameof(District.Location));
                b.Property(x => x.Type).HasColumnName(nameof(District.Type));

                b.HasOne<StateOrProvince>().WithMany().IsRequired().HasForeignKey(x => x.StateOrProvinceId);
            });

            builder.Entity<Vendor>(b =>
            {
                b.ToTable(options.TablePrefix + "Vendors", options.Schema);
                b.HasKey(x => x.Id);
                b.ConfigureFullAudited();


                b.Property(x => x.Name).IsRequired().HasMaxLength(VendorConsts.MaxNameLength).HasColumnName(nameof(Vendor.Name));
                b.Property(x => x.Slug).IsRequired().HasMaxLength(VendorConsts.MaxSlugLength).HasColumnName(nameof(Vendor.Slug));
                b.Property(x => x.Description).HasColumnName(nameof(Vendor.Description));
                b.Property(x => x.Email).IsRequired().HasColumnName(nameof(Vendor.Email));
                b.Property(x => x.IsActive).IsRequired().HasColumnName(nameof(Vendor.IsActive));
            });

            builder.Entity<Widget>(b =>
            {
                b.ToTable(options.TablePrefix + "Widgets", options.Schema);
                b.HasKey(x => x.Id);


                b.Property(x => x.Name).IsRequired().HasMaxLength(WidgetConsts.MaxNameLength).HasColumnName(nameof(Widget.Name));
                b.Property(x => x.ViewComponentName).HasColumnName(nameof(Widget.ViewComponentName));
                b.Property(x => x.CreateUrl).HasColumnName(nameof(Widget.CreateUrl));
                b.Property(x => x.EditUrl).HasColumnName(nameof(Widget.EditUrl));
                b.Property(x => x.IsPublished).HasColumnName(nameof(Widget.IsPublished));
            });

            builder.Entity<WidgetZone>(b =>
            {
                b.ToTable(options.TablePrefix + "WidgetZones", options.Schema);
                b.HasKey(x => x.Id);


                b.Property(x => x.Name).IsRequired().HasMaxLength(WidgetConsts.MaxNameLength).HasColumnName(nameof(WidgetZone.Name));
                b.Property(x => x.Description).HasColumnName(nameof(WidgetZone.Description));
            });

            builder.Entity<WidgetInstance>(b =>
            {
                b.ToTable(options.TablePrefix + "WidgetInstances", options.Schema);
                b.HasKey(x => x.Id);
                b.ConfigureFullAudited();


                b.Property(x => x.WidgetId).HasColumnName(nameof(WidgetInstance.WidgetId));
                b.Property(x => x.WidgetZoneId).HasColumnName(nameof(WidgetInstance.WidgetZoneId));
                b.Property(x => x.Name).IsRequired().HasMaxLength(WidgetConsts.MaxNameLength).HasColumnName(nameof(WidgetInstance.Name));
                b.Property(x => x.PublishStart).HasColumnName(nameof(WidgetInstance.PublishStart));
                b.Property(x => x.PublishEnd).HasColumnName(nameof(WidgetInstance.PublishEnd));
                b.Property(x => x.DisplayOrder).HasColumnName(nameof(WidgetInstance.DisplayOrder));
                b.Property(x => x.Data).HasColumnName(nameof(WidgetInstance.Data));
                b.Property(x => x.HtmlData).HasColumnName(nameof(WidgetInstance.HtmlData));

                b.HasOne<Widget>().WithMany().HasForeignKey(x => x.WidgetId).IsRequired();
                b.HasOne<WidgetZone>().WithMany().HasForeignKey(x => x.WidgetZoneId).IsRequired();
            });
        }
    }
}