using LeaveManagement.Samples;
using Xunit;

namespace LeaveManagement.EntityFrameworkCore.Domains;

[Collection(LeaveManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<LeaveManagementEntityFrameworkCoreTestModule>
{

}
