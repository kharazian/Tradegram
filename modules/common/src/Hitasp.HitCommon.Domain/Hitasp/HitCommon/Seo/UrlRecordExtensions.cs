namespace Hitasp.HitCommon.Seo
{
    public static class UrlRecordExtensions
    {
        public static ISeoData ToSeoData(this IUrlRecord urlRecord)
        {
            return new SeoData(
                id: urlRecord.Id,
                entityName: urlRecord.EntityName,
                slug: urlRecord.Slug,
                isActive: urlRecord.IsActive,
                entityId: urlRecord.EntityId
            );
        }
    }
}