using Allegory.Sample.Localization;
using Volo.Abp.Application.Services;

namespace Allegory.Sample
{
    public class SampleAppService : ApplicationService
    {
        protected SampleAppService()
        {
            LocalizationResource = typeof(SampleResource);
        }
    }
}
