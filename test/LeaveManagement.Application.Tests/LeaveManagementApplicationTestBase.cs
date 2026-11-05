using Volo.Abp.Modularity;

namespace LeaveManagement;

public abstract class LeaveManagementApplicationTestBase<TStartupModule> : LeaveManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
