using System;
using System.Linq;
using System.Threading.Tasks;
using Allegory.Sample.Products;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Allegory.Sample.EntityFrameworkCore.Samples
{
    public class ProductRepositoryTests : SampleEntityFrameworkCoreTestBase
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = GetRequiredService<IRepository<Product, Guid>>();
        }

        [Fact]
        public async Task Should_Query_Product()
        {
            // Need to manually start Unit Of Work because FirstOrDefaultAsync should be executed while db connection / context is available.
            await WithUnitOfWorkAsync(async () =>
            {
                //Act
                var product1 = await _productRepository
                    .Where(p => p.Code == "P-1")
                    .FirstOrDefaultAsync();

                //Assert
                product1.ShouldNotBeNull();
            });
        }
    }
}
