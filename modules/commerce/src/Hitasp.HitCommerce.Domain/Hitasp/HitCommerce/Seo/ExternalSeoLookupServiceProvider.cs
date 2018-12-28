using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Seo;

namespace Hitasp.HitCommerce.Seo
{
    public class ExternalSeoLookupServiceProvider : IExternalSeoLookupServiceProvider
    {
        private readonly IUrlRecordRepository _urlRecordRepository;

        public ExternalSeoLookupServiceProvider(IUrlRecordRepository urlRecordRepository)
        {
            _urlRecordRepository = urlRecordRepository;
        }

        public async Task<ISeoData> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return (
                await _urlRecordRepository.FindAsync(
                    id,
                    cancellationToken: cancellationToken
                )
            ).ToSeoData();
        }

        public async Task<ISeoData> FindBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return (
                await _urlRecordRepository.FindBySlugAsync(
                    slug,
                    cancellationToken: cancellationToken
                )
            ).ToSeoData();
        }
    }
}