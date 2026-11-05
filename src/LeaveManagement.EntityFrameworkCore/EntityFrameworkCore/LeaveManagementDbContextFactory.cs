using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LeaveManagement.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class LeaveManagementDbContextFactory : IDesignTimeDbContextFactory<LeaveManagementDbContext>
{
    public LeaveManagementDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        LeaveManagementEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<LeaveManagementDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new LeaveManagementDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../LeaveManagement.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}
