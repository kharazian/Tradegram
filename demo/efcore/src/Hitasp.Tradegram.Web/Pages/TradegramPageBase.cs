using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Hitasp.Tradegram.Localization.Tradegram;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.Tradegram.Pages
{
    public abstract class TradegramPageBase : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<TradegramResource> L { get; set; }
    }
}
