using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Allegory.Sample.Data
{
    public class NullSampleDbSchemaMigrator : ISampleDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync() => Task.CompletedTask;
    }
}
