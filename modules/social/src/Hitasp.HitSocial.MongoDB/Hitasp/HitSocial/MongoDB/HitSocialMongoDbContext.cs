using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitSocial.MongoDB
{
    [ConnectionStringName("HitSocial")]
    public class HitSocialMongoDbContext : AbpMongoDbContext, IHitSocialMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = HitSocialConsts.DefaultDbTablePrefix;

        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureHitSocial(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}