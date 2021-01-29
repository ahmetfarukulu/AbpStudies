using System.Threading.Tasks;

namespace Allegory.Sample.Data
{
    public interface ISampleDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
