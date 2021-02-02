using Allegory.Sample.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Allegory.Sample.Controllers
{
    public abstract class SampleContoller : AbpController
    {
        protected SampleContoller()
        {
            LocalizationResource = typeof(SampleResource);
        }
    }
}
