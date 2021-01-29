using System;
using System.Threading.Tasks;
using Allegory.Sample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Allegory.Sample.EntityFrameworkCore
{
    public class EntityFrameworkCoreSampleDbSchemaMigrator : ISampleDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;
        public EntityFrameworkCoreSampleDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            await _serviceProvider
                .GetRequiredService<SampleMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
