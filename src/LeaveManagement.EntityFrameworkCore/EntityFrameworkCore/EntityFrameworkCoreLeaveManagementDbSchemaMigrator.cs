using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LeaveManagement.Data;
using Volo.Abp.DependencyInjection;

namespace LeaveManagement.EntityFrameworkCore;

public class EntityFrameworkCoreLeaveManagementDbSchemaMigrator
    : ILeaveManagementDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreLeaveManagementDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LeaveManagementDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<LeaveManagementDbContext>()
            .Database
            .MigrateAsync();
    }
}
