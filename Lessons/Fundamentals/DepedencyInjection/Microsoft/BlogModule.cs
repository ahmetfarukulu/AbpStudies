using Volo.Abp.Modularity;

namespace DepedencyInjection
{
    //Since ABP is a modular framework, every module defines it's own services and registers via dependency injection in it's own seperate module class
    public class BlogModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //register dependencies here
        }
    }
}
