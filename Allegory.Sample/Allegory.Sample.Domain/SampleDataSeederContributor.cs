using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Allegory.Sample
{
    public class SampleDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        public SampleDataSeederContributor()
        {
            //dependency inject repository
        }
        public Task SeedAsync(DataSeedContext context)
        {
            //seed data

            return Task.CompletedTask;
        }
    }
}
