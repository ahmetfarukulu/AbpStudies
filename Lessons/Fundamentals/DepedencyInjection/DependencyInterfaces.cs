using Volo.Abp.DependencyInjection;

namespace DepedencyInjection
{
    public class TaxCalculator : ITransientDependency
    {
        //If you implement these interfaces, your class is registered to dependency injection automatically

        //ITransientDependency to register with transient lifetime.
        //ISingletonDependency to register with singleton lifetime.
        //IScopedDependency to register with scoped lifetime.
    }
}
