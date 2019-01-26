using AutoMapper;
using Hitasp.HitCommerce.Catalog.Brands.Dtos;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Dtos;
using Hitasp.HitCommerce.Catalog.Dtos;

namespace Hitasp.HitCommerce.Catalog
{
    public class CatalogApplicationAutoMapperProfile : Profile
    {
        public CatalogApplicationAutoMapperProfile()
        {
            #region Brands

            CreateMap<Manufacturer, BrandDto>();

            CreateMap<BrandCreateDto, Manufacturer>()
                .ConstructUsing(x =>
                    new Manufacturer(x.Name, x.Slug, x.Description, x.PictureId, x.BrandTemplateId))
                .BeforeMap((src, dest) =>
                {
                    dest.SetMetaData(src.MetaTitle, src.MetaKeywords, src.MetaDescription);
                    dest.SetAsPublished(src.IsPublished);
                    dest.SetDisplayOrder(src.DisplayOrder);
                });

            CreateMap<BrandUpdateDto, Manufacturer>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetSlug(src.Slug);
                    dest.SetMetaData(src.MetaTitle, src.MetaKeywords, src.MetaDescription);
                    dest.SetAsPublished(src.IsPublished);
                    dest.SetPicture(src.PictureId);

                    dest.SetDescription(src.Description);
                    dest.SetDisplayOrder(src.DisplayOrder);

                    dest.SetTemplate(src.BrandTemplateId);
                });

            CreateMap<BrandTemplate, BrandTemplateDto>();

            CreateMap<BrandTemplateCreateDto, BrandTemplate>()
                .ConstructUsing(x =>
                    new BrandTemplate(x.Name, x.ViewPath));

            CreateMap<BrandTemplateUpdateDto, BrandTemplate>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetViewPath(src.ViewPath);
                });

            #endregion

            #region Categories

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryThumbnailDto>();

            CreateMap<CategoryCreateDto, Category>()
                .ConstructUsing(x =>
                    new Category(x.Name, x.Slug, x.Description, x.PictureId, x.CategoryTemplateId, x.ParentCategoryId))
                .BeforeMap((src, dest) =>
                {
                    dest.SetMetaData(src.MetaTitle, src.MetaKeywords, src.MetaDescription);
                    dest.SetAsPublished(src.IsPublished);
                    dest.SetDisplayOrder(src.DisplayOrder);
                    
                    dest.SetAsMenuItem(src.IncludeInTopMenu);
                    dest.SetAsHomePageItem(src.ShowOnHomePage);
                });

            CreateMap<CategoryUpdateDto, Category>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetSlug(src.Slug);
                    dest.SetMetaData(src.MetaTitle, src.MetaKeywords, src.MetaDescription);
                    dest.SetAsPublished(src.IsPublished);
                    dest.SetPicture(src.PictureId);
                    dest.SetDescription(src.Description);
                    dest.SetDisplayOrder(src.DisplayOrder);
                    dest.SetCategoryTemplate(src.CategoryTemplateId);
                    dest.SetAsMenuItem(src.IncludeInTopMenu);
                    dest.SetAsHomePageItem(src.ShowOnHomePage);
                    
                    if (src.ParentCategoryId.HasValue)
                    {
                        dest.SetParentCategory(src.ParentCategoryId.Value);
                    }
                });

            CreateMap<CategoryTemplate, CategoryTemplateDto>();

            CreateMap<CategoryTemplateCreateDto, CategoryTemplate>()
                .ConstructUsing(x =>
                    new CategoryTemplate(x.Name, x.ViewPath));

            CreateMap<CategoryTemplateUpdateDto, CategoryTemplate>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetViewPath(src.ViewPath);
                });

            #endregion

            #region Common

            CreateMap<ThumbnailImage, ThumbnailImageDto>();

            #endregion
        }
    }
}