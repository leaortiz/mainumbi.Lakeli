using Volo.Abp.Settings;

namespace mainumbi.Lakeli.Settings;

public class LakeliSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(LakeliSettings.MySetting1));
    }
}
