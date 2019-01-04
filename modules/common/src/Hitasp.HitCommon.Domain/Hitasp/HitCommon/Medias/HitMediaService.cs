using System.IO;
using System.Threading.Tasks;
using MimeDetective.Extensions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Storage;

namespace Hitasp.HitCommon.Medias
{
    public class MediaService : IMediaService, ITransientDependency
    {
        private const string DefaultStoreName = "MediaStore";
        private readonly IGuidGenerator _guidGenerator;
        private readonly IMediaRepository _mediaRepository;
        private readonly IAbpStore _store;

        public MediaService(
            IMediaRepository mediaRepository,
            IAbpStorageFactory storageFactory,
            IGuidGenerator guidGenerator)
        {
            _mediaRepository = mediaRepository;
            _guidGenerator = guidGenerator;
            _store = storageFactory.GetStore(DefaultStoreName);
        }

        public async Task<string> GetMediaUrl(Media media)
        {
            return await GetMediaUrl(media == null ? "no-image.png" : media.UniqueFileName);
        }

        public async Task<string> GetMediaUrl(string uniqueFileName)
        {
            var media = await _mediaRepository.FindByUniqueFileName(uniqueFileName);
            var file = await _store.GetAsync(media.ToString());

            return file.Path;
        }

        public async Task<Media> SaveMediaAsync(Stream mediaBinaryStream, string fileName, string rootDirectory)
        {
            var fileType = await mediaBinaryStream.GetFileTypeAsync();

            var media = new Media
            (
                _guidGenerator.Create(),
                fileName,
                rootDirectory,
                fileType.ToString(),
                fileType.Mime
            );

            await _store.SaveAsync(
                mediaBinaryStream,
                media.ToString(),
                media.MimeType);

            return await _mediaRepository.InsertAsync(media);
        }

        public async Task DeleteMediaAsync(Media media)
        {
            await _store.DeleteAsync(Path.Combine(media.RootDirectory, media.UniqueFileName));
            await _mediaRepository.DeleteAsync(media.Id);
        }

        public async Task DeleteMediaAsync(string uniqueFileName)
        {
            var media = await _mediaRepository.FindByUniqueFileName(uniqueFileName);
            await DeleteMediaAsync(media);
        }
    }
}