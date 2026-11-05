using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LeaveManagement.Data;

/* This is used if database provider does't define
 * ILeaveManagementDbSchemaMigrator implementation.
 */
public class NullLeaveManagementDbSchemaMigrator : ILeaveManagementDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
