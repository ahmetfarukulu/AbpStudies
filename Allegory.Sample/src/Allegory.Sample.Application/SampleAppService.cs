using Allegory.Sample.Localization;
using Volo.Abp.Application.Services;

namespace Allegory.Sample
{
    public abstract class SampleAppService : ApplicationService
    {
        protected SampleAppService()
        {
            LocalizationResource = typeof(SampleResource);
        }
    }
}
