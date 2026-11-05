using LeaveManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LeaveManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LeaveManagementEntityFrameworkCoreModule),
    typeof(LeaveManagementApplicationContractsModule)
)]
public class LeaveManagementDbMigratorModule : AbpModule
{
}
