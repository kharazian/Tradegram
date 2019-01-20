﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Assets;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    public class MongoAssetBaseRepository<TAsset, TContext> : MongoDbRepository<TContext, TAsset, Guid>,
        IAssetBaseRepository<TAsset>
        where TAsset : Asset
        where TContext : IAbpMongoDbContext
    {
        public MongoAssetBaseRepository(IMongoDbContextProvider<TContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<TAsset> FindByUniqueNameAsync(string uniqueName,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(x => x.UniqueName == uniqueName, GetCancellationToken(cancellationToken));
        }

        public async Task<List<TAsset>> GetListAsync(Guid spaceId, bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.SpaceId == spaceId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public List<TAsset> GetList(Guid spaceId, bool includeDetails = false)
        {
            return GetMongoQueryable().Where(x => x.SpaceId == spaceId).ToList();
        }
    }
}