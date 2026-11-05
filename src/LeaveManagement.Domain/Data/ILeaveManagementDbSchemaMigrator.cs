using System.Threading.Tasks;

namespace LeaveManagement.Data;

public interface ILeaveManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
