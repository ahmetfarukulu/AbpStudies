using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;

namespace Architecture
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddApplication<SomeModule>();
            var serviceProvider = services.BuildServiceProvider();

            var test = serviceProvider.GetService<ITestService>();
            test.Do();
        }
    }
    public class SomeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddTransient<ITestService, SomeManager>();
            base.ConfigureServices(context);
        }
    }
    public interface ITestService
    {
        void Do();
    }
    public class SomeManager : ITestService, ITransientDependency
    {
        public void Do()
        {
            Console.WriteLine("Something do it");
        }
    }
}
