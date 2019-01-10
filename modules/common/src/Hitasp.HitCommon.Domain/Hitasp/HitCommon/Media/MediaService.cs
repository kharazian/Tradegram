using System.IO;
using System.Threading.Tasks;
using Hitasp.HitCommon.Assets;
using MimeDetective.Extensions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Storage;

namespace Hitasp.HitCommon.Media
{
    public class MediaService<TMedia> : IMediaService<TMedia>, ITransientDependency
        where TMedia : AssetBase, IMedia
    {
        private const string DefaultStoreName = "MediaStore";
        private readonly IMediaRepository<TMedia> _mediaRepository;
        private readonly IAbpStore _store;

        public MediaService(
            IMediaRepository<TMedia> mediaRepository,
            IAbpStorageFactory storageFactory)
        {
            _mediaRepository = mediaRepository;
            _store = storageFactory.GetStore(DefaultStoreName);
        }

        public async Task<string> GetMediaUrl(TMedia media)
        {
            return await GetMediaUrl(media == null ? "no-image.png" : media.UniqueName);
        }

        public async Task<string> GetMediaUrl(string uniqueName)
        {
            var media = await _mediaRepository.FindByUniqueName(uniqueName);
            var file = await _store.GetAsync(media.ToString());

            return file.Path;
        }

        public async Task<TMedia> SaveMediaAsync(TMedia media, Stream mediaBinaryStream)
        {
            var fileType = await mediaBinaryStream.GetFileTypeAsync();

            await _store.SaveAsync(
                mediaBinaryStream,
                media.ToString(),
                fileType.Mime);

            return await _mediaRepository.InsertAsync(media);
        }

        public async Task DeleteMediaAsync(TMedia media)
        {
            await _store.DeleteAsync(media.ToString());
            await _mediaRepository.DeleteAsync(media.Id);
        }

        public async Task DeleteMediaAsync(string uniqueName)
        {
            var media = await _mediaRepository.FindByUniqueName(uniqueName);
            await DeleteMediaAsync(media);
        }
    }
}