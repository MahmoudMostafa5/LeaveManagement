using LeaveManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace LeaveManagement.Permissions;

public class LeaveManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LeaveManagementPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(LeaveManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
        var leaveGroup = myGroup.AddPermission(
            LeaveManagementPermissions.LeaveRequests.Default, L("Permission:LeaveRequests"));
        leaveGroup.AddChild(LeaveManagementPermissions.LeaveRequests.Create, L("Permission:Create"));
        leaveGroup.AddChild(LeaveManagementPermissions.LeaveRequests.Approve, L("Permission:Approve"));
        leaveGroup.AddChild(LeaveManagementPermissions.LeaveRequests.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LeaveManagementResource>(name);
    }
}
