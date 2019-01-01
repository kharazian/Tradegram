using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Helpers;
using Hitasp.HitCommon.Seo;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Seo
{
    public class UrlRecordService : DomainService, IUrlRecordService
    {
        private readonly IUrlRecordRepository _urlRecordRepository;
        private readonly Dictionary<string, string> _seoCharacterTable;

        protected UrlRecordService(
            IUrlRecordRepository urlRecordRepository)
        {
            _urlRecordRepository = urlRecordRepository;
            _seoCharacterTable = CharHelper.InitializeSeoCharacter();
        }
        
        public async Task DeleteUrlRecordAsync(UrlRecord urlRecord, CancellationToken cancellationToken = default)
        {
            await _urlRecordRepository.DeleteAsync(urlRecord, cancellationToken: cancellationToken);
        }

        public async Task InsertUrlRecordAsync(UrlRecord urlRecord, CancellationToken cancellationToken = default)
        {
            Check.NotNull(urlRecord, nameof(urlRecord));

            await _urlRecordRepository.InsertAsync(urlRecord, cancellationToken: cancellationToken);
        }

        public async Task UpdateUrlRecordAsync(UrlRecord urlRecord, CancellationToken cancellationToken = default)
        {
            Check.NotNull(urlRecord, nameof(urlRecord));

            await _urlRecordRepository.UpdateAsync(urlRecord, autoSave: true, cancellationToken: cancellationToken);
        }

        public async Task<string> GetActiveSlugAsync(Guid entityId, string entityName,
            CancellationToken cancellationToken = default)
        {
            var urlRecord = await _urlRecordRepository.FindByEntityIdAsync(entityId, cancellationToken);

            return urlRecord.EntityName == entityName && urlRecord.IsActive ? urlRecord.Slug : string.Empty;
        }

        public async Task SaveSlugAsync<T>(T entity, string slug, CancellationToken cancellationToken = default)
            where T : ISlugSupported
        {
            Check.NotNull(entity, nameof(entity));

            var entityId = entity.Id;
            var entityName = entity.GetType().Name;

            var query = from ur in _urlRecordRepository.GetList()
                where ur.EntityId == entityId &&
                      ur.EntityName == entityName
                orderby ur.Id descending
                select ur;

            var allUrlRecords = query.ToList();
            var activeUrlRecord = allUrlRecords.FirstOrDefault(x => x.IsActive);

            UrlRecord nonActiveRecordWithSpecifiedSlug;

            if (activeUrlRecord == null && !string.IsNullOrWhiteSpace(slug))
            {
                //find in non-active records with the specified slug
                nonActiveRecordWithSpecifiedSlug = allUrlRecords
                    .FirstOrDefault(
                        x => x.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase) && !x.IsActive);

                if (nonActiveRecordWithSpecifiedSlug != null)
                {
                    //mark non-active record as active
                    nonActiveRecordWithSpecifiedSlug.IsActive = true;
                    await _urlRecordRepository.UpdateAsync(nonActiveRecordWithSpecifiedSlug, cancellationToken: cancellationToken);
                }
                else
                {
                    //new record
                    var urlRecord = new UrlRecord(
                        GuidGenerator.Create(),
                        entityId,
                        entityName,
                        slug, true);

                    await _urlRecordRepository.InsertAsync(urlRecord, 
                        cancellationToken: cancellationToken);
                }
            }

            if (activeUrlRecord != null && string.IsNullOrWhiteSpace(slug))
            {
                //disable the previous active URL record
                activeUrlRecord.IsActive = false;
                await _urlRecordRepository.UpdateAsync(activeUrlRecord, cancellationToken: cancellationToken);
            }

            if (activeUrlRecord == null || string.IsNullOrWhiteSpace(slug))
                return;

            //it should not be the same slug as in active URL record
            if (activeUrlRecord.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase))
                return;

            //find in non-active records with the specified slug
            nonActiveRecordWithSpecifiedSlug = allUrlRecords
                .FirstOrDefault(x => x.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase) && !x.IsActive);

            if (nonActiveRecordWithSpecifiedSlug != null)
            {
                //mark non-active record as active
                nonActiveRecordWithSpecifiedSlug.IsActive = true;
                await _urlRecordRepository.UpdateAsync(nonActiveRecordWithSpecifiedSlug, cancellationToken: cancellationToken);

                //disable the previous active URL record
                activeUrlRecord.IsActive = false;
                await _urlRecordRepository.UpdateAsync(activeUrlRecord, cancellationToken: cancellationToken);
            }
            else
            {
                //insert new record
                //we do not update the existing record because we should track all previously entered slugs
                //to ensure that URLs will work fine
                var urlRecord = new UrlRecord(
                    GuidGenerator.Create(),
                    entityId,
                    entityName,
                    slug,
                    true
                );

                await _urlRecordRepository.InsertAsync(urlRecord, cancellationToken: cancellationToken);

                //disable the previous active URL record
                activeUrlRecord.IsActive = false;
                await _urlRecordRepository.UpdateAsync(activeUrlRecord, cancellationToken: cancellationToken);
            }
        }

        public async Task<string> GetSeNameAsync<T>(T entity, bool returnDefaultValue = true,
            CancellationToken cancellationToken = default) where T : ISlugSupported
        {
            Check.NotNull(entity, nameof(entity));

            var entityName = entity.GetType().Name;
            return await GetSeNameAsync(entity.Id, entityName, cancellationToken);
        }

        public async Task<string> GetSeNameAsync(Guid entityId, string entityName,
            CancellationToken cancellationToken = default)
        {
             return await GetActiveSlugAsync(entityId, entityName, cancellationToken);
        }

        public async Task<string> GetSeNameAsync(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls,
            CancellationToken cancellationToken = default)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var task = Task.Run(() =>
            {
                const string okChars = "abcdefghijklmnopqrstuvwxyz1234567890 _-";
                
                name = name.Trim().ToLowerInvariant();

                var sb = new StringBuilder();

                foreach (var c in name.ToCharArray())
                {
                    var c2 = c.ToString();

                    if (convertNonWesternChars)
                    {
                        if (_seoCharacterTable?.ContainsKey(c2) ?? false)
                            c2 = _seoCharacterTable[c2];
                    }

                    if (allowUnicodeCharsInUrls)
                    {
                        if (char.IsLetterOrDigit(c) || okChars.Contains(c2))
                            sb.Append(c2);
                    }
                    else if (okChars.Contains(c2))
                    {
                        sb.Append(c2);
                    }
                }

                var name2 = sb.ToString();
                name2 = name2.Replace(" ", "-");

                while (name2.Contains("--"))
                    name2 = name2.Replace("--", "-");

                while (name2.Contains("__"))
                    name2 = name2.Replace("__", "_");
                return name2;
            }, cancellationToken);

            return await task;
        }

        public async Task<string> ValidateSeNameAsync<T>(T entity, string seName, string name, bool ensureNotEmpty,
            CancellationToken cancellationToken = default) where T : ISlugSupported
        {
            Check.NotNull(entity, nameof(entity));

            var entityName = entity.GetType().Name;
            
            return await ValidateSeNameAsync(entity.Id, entityName, seName, name, ensureNotEmpty, cancellationToken);
        }

        public async Task<string> ValidateSeNameAsync(Guid entityId, string entityName, string seName, string name,
            bool ensureNotEmpty, CancellationToken cancellationToken = default)
        {
            //use name if sename is not specified
            if (string.IsNullOrWhiteSpace(seName) && !string.IsNullOrWhiteSpace(name))
                seName = name;

            //validation
            //TODO: convertNonWesternChars? & allowUnicodeCharsInUrls? should get from settings
            seName = await GetSeNameAsync(seName, true, true, cancellationToken);

            if (string.IsNullOrWhiteSpace(seName))
            {
                if (ensureNotEmpty)
                {
                    //use entity identifier as sename if empty
                    seName = entityId.ToString();
                }
                else
                {
                    //return. no need for further processing
                    return seName;
                }
            }

            //ensure this sename is not reserved yet
            var i = 2;
            var tempSeName = seName;
            while (true)
            {
                //check whether such slug already exists (and that is not the current entity)
                var urlRecord = await _urlRecordRepository.FindBySlugAsync(tempSeName, cancellationToken);
                var reserved = urlRecord != null && !(urlRecord.EntityId == entityId && urlRecord.EntityName.Equals(entityName, StringComparison.InvariantCultureIgnoreCase));

                //TODO more validation
                
                if (!reserved)
                    break;

                tempSeName = $"{seName}-{i}";
                i++;
            }

            seName = tempSeName;

            return seName;
        }
    }
}