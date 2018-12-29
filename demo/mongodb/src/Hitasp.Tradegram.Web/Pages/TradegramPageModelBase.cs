using Hitasp.Tradegram.Localization.Tradegram;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hitasp.Tradegram.Pages
{
    public abstract class TradegramPageModelBase : AbpPageModel
    {
        protected TradegramPageModelBase()
        {
            LocalizationResourceType = typeof(TradegramResource);
        }
    }
}