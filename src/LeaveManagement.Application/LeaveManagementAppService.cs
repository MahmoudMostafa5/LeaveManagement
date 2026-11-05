using LeaveManagement.Localization;
using Volo.Abp.Application.Services;

namespace LeaveManagement;

/* Inherit your application services from this class.
 */
public abstract class LeaveManagementAppService : ApplicationService
{
    protected LeaveManagementAppService()
    {
        LocalizationResource = typeof(LeaveManagementResource);
    }
}
