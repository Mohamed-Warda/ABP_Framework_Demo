using Microsoft.Extensions.Localization;
using ABPDemo.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ABPDemo;

[Dependency(ReplaceServices = true)]
public class ABPDemoBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ABPDemoResource> _localizer;

    public ABPDemoBrandingProvider(IStringLocalizer<ABPDemoResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
