using Volo.Abp.Settings;

namespace LeaveManagement.Settings;

public class LeaveManagementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(LeaveManagementSettings.MySetting1));
    }
}
