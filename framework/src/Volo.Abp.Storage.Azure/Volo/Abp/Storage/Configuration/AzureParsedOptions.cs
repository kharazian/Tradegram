﻿using System.Collections.Generic;
using Volo.Abp.Storage.Azure;

namespace Volo.Abp.Storage.Configuration
{
    public class AzureParsedOptions : IAbpParsedOptions<AzureProviderInstanceOptions, AzureStoreOptions,
        AzureScopedStoreOptions>
    {
        public string Name => AbpAzureStorageProvider.ProviderName;

        public IReadOnlyDictionary<string, string> ConnectionStrings { get; set; }

        public IReadOnlyDictionary<string, AzureProviderInstanceOptions> ParsedProviderInstances { get; set; }

        public IReadOnlyDictionary<string, AzureStoreOptions> ParsedStores { get; set; }

        public IReadOnlyDictionary<string, AzureScopedStoreOptions> ParsedScopedStores { get; set; }

        public void BindProviderInstanceOptions(AzureProviderInstanceOptions providerInstanceOptions)
        {
            if (!string.IsNullOrEmpty(providerInstanceOptions.ConnectionStringName)
                && string.IsNullOrEmpty(providerInstanceOptions.ConnectionString))
            {
                if (!ConnectionStrings.ContainsKey(providerInstanceOptions.ConnectionStringName))
                {
                    throw new BadProviderConfigurationException(
                        providerInstanceOptions.Name,
                        $"The ConnectionString '{providerInstanceOptions.ConnectionStringName}' cannot be found.");
                }

                providerInstanceOptions.ConnectionString = ConnectionStrings[providerInstanceOptions.ConnectionStringName];
            }
        }

        public void BindStoreOptions(AzureStoreOptions storeOptions, AzureProviderInstanceOptions providerInstanceOptions = null)
        {
            storeOptions.FolderName = storeOptions.FolderName.ToLowerInvariant();

            if (!string.IsNullOrEmpty(storeOptions.ConnectionStringName)
                && string.IsNullOrEmpty(storeOptions.ConnectionString))
            {
                if (!ConnectionStrings.ContainsKey(storeOptions.ConnectionStringName))
                {
                    throw new BadStoreConfigurationException(
                        storeOptions.Name,
                        $"The ConnectionString '{storeOptions.ConnectionStringName}' cannot be found.");
                }

                storeOptions.ConnectionString = ConnectionStrings[storeOptions.ConnectionStringName];
            }

            if (providerInstanceOptions == null
                || storeOptions.ProviderName != providerInstanceOptions.Name)
            {
                return;
            }

            if (string.IsNullOrEmpty(storeOptions.ConnectionString))
            {
                storeOptions.ConnectionString = providerInstanceOptions.ConnectionString;
            }
        }
    }
}