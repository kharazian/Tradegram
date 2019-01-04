using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    public static class CatalogBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                //Register mappings here. Example:
                //BsonClassMap.RegisterClassMap<Question>(map =>
                //{
                //    map.AutoMap();
                //});
            });
        }
    }
}