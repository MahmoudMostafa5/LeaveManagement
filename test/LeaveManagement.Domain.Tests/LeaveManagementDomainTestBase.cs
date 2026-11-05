using Volo.Abp.Modularity;

namespace LeaveManagement;

/* Inherit from this class for your domain layer tests. */
public abstract class LeaveManagementDomainTestBase<TStartupModule> : LeaveManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
