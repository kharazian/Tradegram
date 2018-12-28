using JetBrains.Annotations;

namespace Hitasp.HitCommon.Seo
{
    public interface IUpdateUrlRecord
    {
        bool Update([NotNull] ISeoData seoData);
    }
}