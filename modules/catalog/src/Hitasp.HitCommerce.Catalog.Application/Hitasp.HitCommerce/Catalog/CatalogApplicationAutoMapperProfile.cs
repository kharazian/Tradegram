using AutoMapper;
using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Brands.Dtos;

namespace Hitasp.HitCommerce.Catalog
{
    public class CatalogApplicationAutoMapperProfile : Profile
    {
        public CatalogApplicationAutoMapperProfile()
        {
            CreateMap<Brand, BrandDto>();

            CreateMap<BrandCreateDto, Brand>()
                .ConstructUsing(x =>
                    new Brand(x.Name, x.Slug, x.Description, x.PictureId, x.BrandTemplateId))
                .BeforeMap((src, dest) =>
                {
                    dest.SetMetaData(src.MetaTitle, src.MetaKeywords, src.MetaDescription);
                    dest.SetAsPublished(src.IsPublished);
                    dest.SetDisplayOrder(src.DisplayOrder);
                    dest.SetLanguageCode(src.LanguageCode);
                    dest.SetPriceRange(src.PriceRanges);
                });

            CreateMap<BrandUpdateDto, Brand>()
                .BeforeMap((src, dest) =>
                {
                    dest.SetName(src.Name);
                    dest.SetSlug(src.Slug);
                    dest.SetMetaData(src.MetaTitle, src.MetaKeywords, src.MetaDescription);
                    dest.SetAsPublished(src.IsPublished);
                    dest.SetPicture(src.PictureId);

                    dest.SetDescription(src.Description);
                    dest.SetDisplayOrder(src.DisplayOrder);
                    dest.SetLanguageCode(src.LanguageCode);

                    dest.SetTemplate(src.BrandTemplateId);
                    dest.SetPriceRange(src.PriceRanges);
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
        }
    }
}