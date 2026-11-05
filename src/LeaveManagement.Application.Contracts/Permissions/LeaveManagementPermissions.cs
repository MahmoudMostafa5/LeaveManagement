namespace LeaveManagement.Permissions;

public static class LeaveManagementPermissions
{
    public const string GroupName = "LeaveManagement";



    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class LeaveRequests
    {
        public const string Default = GroupName + ".LeaveRequests";
        public const string Create = Default + ".Create";
        public const string Approve = Default + ".Approve";
        public const string Delete = Default + ".Delete";
    }
}
