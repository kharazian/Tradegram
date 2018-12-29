using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Hitasp.Tradegram.Branding
{
    [Dependency(ReplaceServices = true)]
    public class TradegramBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Tradegram";
    }
}
