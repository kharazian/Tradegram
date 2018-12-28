using System.IO;
using System.Threading.Tasks;
using MimeDetective.Extensions;
using Volo.Abp.Domain.Services;
using Volo.Abp.Storage;

namespace Hitasp.HitCommerce.Medias
{
    public class MediaService : DomainService, IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IAbpStore _mediaStore;

        public MediaService(IMediaRepository mediaRepository, IAbpStorageFactory storageFactory)
        {
            _mediaRepository = mediaRepository;
            _mediaStore = storageFactory.GetStore(HitCommerceConsts.DefaultMediaStoreName);
        }

        public async Task<string> GetMediaUrl(Media media)
        {
            return await GetMediaUrl(media == null ? "no-image.png" : media.FileName);
        }

        public async Task<string> GetMediaUrl(string fileName)
        {
            var media = await _mediaRepository.GetByFileName(fileName);
            var file = await _mediaStore.GetAsync(Path.Combine(media.RootDirectory, media.UniqueFileName));

            return file.Path;
        }

        public async Task<string> GetThumbnailUrl(Media media)
        {
            //TODO Generate thumbnail from media URL
            return await GetMediaUrl(media);
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string rootDirectory,
            string caption = null)
        {
            var media = new Media(
                GuidGenerator.Create(),
                fileName,
                rootDirectory
            );

            if (!string.IsNullOrWhiteSpace(caption))
            {
                media.SetCaption(caption);
            }
            var fileType = await mediaBinaryStream.GetFileTypeAsync();
            media.MimeType = fileType.Mime;

            await _mediaStore.SaveAsync(
                mediaBinaryStream,
                Path.Combine(media.RootDirectory, media.UniqueFileName),
                media.MimeType);

            await _mediaRepository.InsertAsync(media);
        }

        public async Task DeleteMediaAsync(Media media)
        {
            await _mediaStore.DeleteAsync(Path.Combine(media.RootDirectory, media.UniqueFileName));
            await _mediaRepository.DeleteAsync(media);
        }

        public async Task DeleteMediaAsync(string fileName)
        {
            var media = await _mediaRepository.GetByFileName(fileName);
            await DeleteMediaAsync(media);
        }
    }
}