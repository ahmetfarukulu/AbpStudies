using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DepedencyInjection
{
    public class ConventionalRegistration : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //ABP introduces conventional service registration. You need not do anything to register a service by convention. It's automatically done. If you want to disable it, you can set SkipAutoServiceRegistration to true by overriding the PreConfigureServices method
            SkipAutoServiceRegistration = true;
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Once you skip auto registration, you should manually register your services. In that case, AddAssemblyOf extension method can help you to register all your services by convention
            context.Services.AddAssemblyOf<BlogModule>();
        }
    }
}
