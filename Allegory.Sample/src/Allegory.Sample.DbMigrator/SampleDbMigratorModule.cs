using Allegory.Sample.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Allegory.Sample.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(SampleEntityFrameworkCoreDbMigrationsModule)
        //typeof(SampleApplicationContractsModule) => Create AppContract project
        )]
    public class SampleDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
