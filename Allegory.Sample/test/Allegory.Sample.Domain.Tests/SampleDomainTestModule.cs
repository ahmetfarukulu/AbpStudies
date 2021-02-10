using Allegory.Sample.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.Sample
{
    [DependsOn(
      typeof(SampleEntityFrameworkCoreTestModule)
      )]
    public class SampleDomainTestModule : AbpModule
    {

    }
}
