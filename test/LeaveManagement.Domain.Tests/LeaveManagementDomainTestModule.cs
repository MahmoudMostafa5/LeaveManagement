using Volo.Abp.Modularity;

namespace LeaveManagement;

[DependsOn(
    typeof(LeaveManagementDomainModule),
    typeof(LeaveManagementTestBaseModule)
)]
public class LeaveManagementDomainTestModule : AbpModule
{

}
