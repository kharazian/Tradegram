using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace Hitasp.HitCommon.Seo
{
    public abstract class
        UrlRecordLookupService<TUrlRecord, TUrlRecordRepository> : IUrlRecordLookupService<TUrlRecord>,
            ITransientDependency
        where TUrlRecord : class, IUrlRecord
        where TUrlRecordRepository : IUrlRecordRepositoryBase<TUrlRecord>
    {
        public IExternalSeoLookupServiceProvider UrlRecordLookupServiceProvider { get; set; }
        public ILogger<UrlRecordLookupService<TUrlRecord, TUrlRecordRepository>> Logger { get; set; }

        private readonly TUrlRecordRepository _urlRecordRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        protected UrlRecordLookupService(
            TUrlRecordRepository urlRecordRepository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _urlRecordRepository = urlRecordRepository;
            _unitOfWorkManager = unitOfWorkManager;

            Logger = NullLogger<UrlRecordLookupService<TUrlRecord, TUrlRecordRepository>>.Instance;
        }

        public async Task<TUrlRecord> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (UrlRecordLookupServiceProvider == null)
            {
                return await _urlRecordRepository.FindAsync(id, cancellationToken: cancellationToken);
            }

            ISeoData externalUrlRecord;

            try
            {
                externalUrlRecord = await UrlRecordLookupServiceProvider.FindByIdAsync(id, cancellationToken);

                if (externalUrlRecord == null)
                {
                    await WithNewUowAsync(() =>
                        _urlRecordRepository.DeleteAsync(id, cancellationToken: cancellationToken));

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);

                return await _urlRecordRepository.FindAsync(id, cancellationToken: cancellationToken);
            }

            var localUrlRecord = await _urlRecordRepository.FindAsync(id, cancellationToken: cancellationToken);

            if (localUrlRecord == null)
            {
                await WithNewUowAsync(() =>
                    _urlRecordRepository.InsertAsync(CreateUrlRecord(externalUrlRecord),
                        cancellationToken: cancellationToken));

                return await _urlRecordRepository.FindAsync(id, cancellationToken: cancellationToken);
            }

            if (localUrlRecord is IUpdateUrlRecord && ((IUpdateUrlRecord) localUrlRecord).Update(externalUrlRecord))
            {
                await WithNewUowAsync(() =>
                    _urlRecordRepository.UpdateAsync(localUrlRecord, cancellationToken: cancellationToken));
            }
            else
            {
                return localUrlRecord;
            }

            return await _urlRecordRepository.FindAsync(id, cancellationToken: cancellationToken);
        }

        public async Task<TUrlRecord> FindBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            if (UrlRecordLookupServiceProvider == null)
            {
                return await _urlRecordRepository.FindBySlugAsync(slug, cancellationToken);
            }

            ISeoData externalUrlRecord;

            try
            {
                externalUrlRecord =
                    await UrlRecordLookupServiceProvider.FindBySlugAsync(slug, cancellationToken);

                if (externalUrlRecord == null)
                {
                    var localExistingUrlRecord = await _urlRecordRepository.FindBySlugAsync(slug, cancellationToken);

                    if (localExistingUrlRecord != null)
                    {
                        //TODO: Instead of deleting, should be make it passive or something like that?
                        await WithNewUowAsync(() =>
                            _urlRecordRepository.DeleteAsync(localExistingUrlRecord.Id,
                                cancellationToken: cancellationToken));
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);

                return await _urlRecordRepository.FindBySlugAsync(slug, cancellationToken);
            }

            var localUrlRecord = await _urlRecordRepository.FindBySlugAsync(slug, cancellationToken);

            if (localUrlRecord == null)
            {
                await WithNewUowAsync(() =>
                    _urlRecordRepository.InsertAsync(CreateUrlRecord(externalUrlRecord),
                        cancellationToken: cancellationToken));

                return await _urlRecordRepository.FindAsync(externalUrlRecord.Id, cancellationToken: cancellationToken);
            }

            if (localUrlRecord is IUpdateUrlRecord && ((IUpdateUrlRecord) localUrlRecord).Update(externalUrlRecord))
            {
                await WithNewUowAsync(() =>
                    _urlRecordRepository.UpdateAsync(localUrlRecord, cancellationToken: cancellationToken));
            }
            else
            {
                return localUrlRecord;
            }

            return await _urlRecordRepository.FindAsync(externalUrlRecord.Id, cancellationToken: cancellationToken);
        }

       

        protected abstract TUrlRecord CreateUrlRecord(ISeoData externalUrlRecord);

        private async Task WithNewUowAsync(Func<Task> func)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true))
            {
                await func();
                await uow.SaveChangesAsync();
            }
        }
    }
}