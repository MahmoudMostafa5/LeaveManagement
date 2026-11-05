using Xunit;

namespace LeaveManagement.EntityFrameworkCore;

[CollectionDefinition(LeaveManagementTestConsts.CollectionDefinitionName)]
public class LeaveManagementEntityFrameworkCoreCollection : ICollectionFixture<LeaveManagementEntityFrameworkCoreFixture>
{

}
