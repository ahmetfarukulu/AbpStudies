using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace DepedencyInjection
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    public class TaxCalculator2
    {
        //Lifetime: Lifetime of the registration: Singleton, Transient or Scoped.
        //TryRegister: Set true to register the service only if it's not registered before. Uses TryAdd... extension methods of IServiceCollection.
        //ReplaceServices: Set true to replace services if they are already registered before. Uses Replace extension method of IServiceCollection.
    }
}
