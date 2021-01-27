﻿using Allegory.Sample.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Allegory.Sample
{
    [DependsOn(
      typeof(AbpAuditLoggingDomainSharedModule),
      typeof(AbpBackgroundJobsDomainSharedModule),
      typeof(AbpFeatureManagementDomainSharedModule),
      typeof(AbpIdentityDomainSharedModule),
      typeof(AbpIdentityServerDomainSharedModule),
      typeof(AbpPermissionManagementDomainSharedModule),
      typeof(AbpSettingManagementDomainSharedModule),
      typeof(AbpTenantManagementDomainSharedModule)
      )]
    public class SampleDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //Nothing need to configure
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SampleDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<SampleResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/BookStore");

                options.DefaultResourceType = typeof(SampleResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("BookStore", typeof(SampleResource));
            });
        }
    }
}