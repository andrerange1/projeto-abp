using Volo.Abp.Settings;

namespace Abp.Countries.Settings;

public class CountriesSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CountriesSettings.MySetting1));
    }
}
