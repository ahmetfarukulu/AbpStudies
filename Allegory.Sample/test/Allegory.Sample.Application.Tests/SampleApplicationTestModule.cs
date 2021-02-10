using Volo.Abp.Modularity;

namespace Allegory.Sample
{
    [DependsOn(
      typeof(SampleApplicationModule),
      typeof(SampleDomainTestModule)
      )]
    public class SampleApplicationTestModule : AbpModule
    {

    }
}
