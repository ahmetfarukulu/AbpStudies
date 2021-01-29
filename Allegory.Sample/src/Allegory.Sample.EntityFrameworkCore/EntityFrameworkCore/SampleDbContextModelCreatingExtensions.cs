using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Allegory.Sample.EntityFrameworkCore
{
    public static class SampleDbContextModelCreatingExtensions
    {
        public static void ConfigureSample(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            //Custom model mappings here
        }
    }
}
