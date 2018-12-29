using Volo.Abp.Settings;

namespace Hitasp.Tradegram.Settings
{
    public class TradegramSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(TradegramSettings.MySetting1));
        }
    }
}
