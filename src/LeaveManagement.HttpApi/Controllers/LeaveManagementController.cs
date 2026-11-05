using LeaveManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LeaveManagement.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LeaveManagementController : AbpControllerBase
{
    protected LeaveManagementController()
    {
        LocalizationResource = typeof(LeaveManagementResource);
    }
}
