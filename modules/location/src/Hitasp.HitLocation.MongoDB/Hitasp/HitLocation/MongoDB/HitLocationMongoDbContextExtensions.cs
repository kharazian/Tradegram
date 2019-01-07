﻿using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitLocation.MongoDB
{
    public static class HitLocationMongoDbContextExtensions
    {
        public static void ConfigureHitLocation(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HitLocationMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);
        }
    }
}