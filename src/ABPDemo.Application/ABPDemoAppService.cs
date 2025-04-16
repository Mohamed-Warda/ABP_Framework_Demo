using ABPDemo.Localization;
using Volo.Abp.Application.Services;

namespace ABPDemo;

/* Inherit your application services from this class.
 */
public abstract class ABPDemoAppService : ApplicationService
{
    protected ABPDemoAppService()
    {
        LocalizationResource = typeof(ABPDemoResource);
    }
}
