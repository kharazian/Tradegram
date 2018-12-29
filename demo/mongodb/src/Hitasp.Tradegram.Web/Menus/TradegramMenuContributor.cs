using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Hitasp.Tradegram.Localization.Tradegram;
using Volo.Abp.UI.Navigation;

namespace Hitasp.Tradegram.Menus
{
    public class TradegramMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<TradegramResource>>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem("Tradegram.Home", l["Menu:Home"], "/"));
        }
    }
}
