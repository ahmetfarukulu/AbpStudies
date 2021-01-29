using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Allegory.Sample.EntityFrameworkCore
{
    [DependsOn(
       typeof(SampleDomainModule),
       typeof(AbpIdentityEntityFrameworkCoreModule),
       typeof(AbpIdentityServerEntityFrameworkCoreModule),
       typeof(AbpPermissionManagementEntityFrameworkCoreModule),
       typeof(AbpSettingManagementEntityFrameworkCoreModule),
       typeof(AbpEntityFrameworkCoreSqlServerModule),
       typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
       typeof(AbpAuditLoggingEntityFrameworkCoreModule),
       typeof(AbpTenantManagementEntityFrameworkCoreModule),
       typeof(AbpFeatureManagementEntityFrameworkCoreModule)
       )]
    public class SampleEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SampleDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}
