using Volo.Abp.DependencyInjection;

namespace Hitasp.HitCommerce.PDF
{
    public interface IPdfConverter : ITransientDependency
    {
        byte[] Convert(string htmlContent);
    }
}