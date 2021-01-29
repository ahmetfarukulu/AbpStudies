using Allegory.Sample.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Allegory.Sample.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class SampleDbContext : AbpDbContext<SampleDbContext>
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser

                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                //Configure mappings for your additional properties
            });

            builder.ConfigureSample();
        }
    }
}
