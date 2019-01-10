using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Contents
{
    public interface IHasMetaData : IEntity
    {
        string MetaTitle { get; }

        string MetaKeywords { get; }

        string MetaDescription { get; }

        void SetMetaData(string metaTitle, string metaKeywords, string metaDescription);
    }
}