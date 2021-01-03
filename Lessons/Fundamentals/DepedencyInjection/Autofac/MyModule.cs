using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DepedencyInjection
{
    [DependsOn(typeof(AbpAutofacModule))]
    public class MyModule : AbpModule
    {

    }
}
#region ASP.NET Core Application
/*
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<MyWebModule>(options =>
            {
                //Integrate Autofac!
                options.UseAutofac();
            });

            return services.BuildServiceProviderFromFactory();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
*/
#endregion

#region Console Application
/*
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<AppModule>(options =>
            {
                options.UseAutofac(); //Autofac integration
            }))
            {
                //...
            }
        }
    }
*/
#endregion