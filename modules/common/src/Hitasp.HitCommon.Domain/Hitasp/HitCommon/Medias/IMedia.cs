namespace Hitasp.HitCommon.Medias
{
    public interface IMedia
    {
        string FileName { get; set; }

        string RootDirectory { get; set; }

        string MimeType { get; set; }
        
        string UniqueFileName { get; }

        string FileExtension { get; set; }
    }
}