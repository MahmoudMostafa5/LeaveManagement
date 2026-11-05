using LeaveManagement.Samples;
using Xunit;

namespace LeaveManagement.EntityFrameworkCore.Applications;

[Collection(LeaveManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<LeaveManagementEntityFrameworkCoreTestModule>
{

}
