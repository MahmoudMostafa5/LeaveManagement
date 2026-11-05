using Volo.Abp.Modularity;

namespace LeaveManagement;

[DependsOn(
    typeof(LeaveManagementApplicationModule),
    typeof(LeaveManagementDomainTestModule)
)]
public class LeaveManagementApplicationTestModule : AbpModule
{

}
