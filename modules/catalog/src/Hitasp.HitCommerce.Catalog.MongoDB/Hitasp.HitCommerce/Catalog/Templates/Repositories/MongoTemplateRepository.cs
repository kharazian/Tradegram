using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Templates.Repositories
{
    public class MongoTemplateRepository : MongoDbRepository<ICatalogMongoDbContext, Template, Guid>,
        ITemplateRepository
    {
        public MongoTemplateRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Template> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(t => t.Name == name).FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }
    }
}