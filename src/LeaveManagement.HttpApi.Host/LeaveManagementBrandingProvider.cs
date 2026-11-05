using Microsoft.Extensions.Localization;
using LeaveManagement.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LeaveManagement;

[Dependency(ReplaceServices = true)]
public class LeaveManagementBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<LeaveManagementResource> _localizer;

    public LeaveManagementBrandingProvider(IStringLocalizer<LeaveManagementResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];

    public override string? LogoUrl => "~/images/logo/leptonxlite/logo-light-thumbnail.png";

    public override string? LogoIconUrl => "~/images/logo/leptonxlite/logo-dark-thumbnail.png";
}
