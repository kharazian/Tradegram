namespace Hitasp.HitCommon.PDF
{
    public interface IPdfConverter
    {
        byte[] Convert(string htmlContent);
    }
}