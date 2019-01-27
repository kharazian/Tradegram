﻿using System;
using System.Threading.Tasks;

namespace Volo.Abp.Identity
{
    public interface IIdentityDataSeeder
    {
        Task<IdentityDataSeedResult> SeedAsync(
            string adminUserPassword,
            Guid? tenantId = null);
    }
}