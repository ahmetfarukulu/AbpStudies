using System;
using System.Threading.Tasks;
using Allegory.Sample.Products;
using Shouldly;
using Xunit;

namespace Allegory.Sample.Samples
{
    public class ProductDomainTests : SampleDomainTestBase
    {
        private readonly ProductManager _productManager;

        public ProductDomainTests()
        {
            _productManager = GetRequiredService<ProductManager>();
        }

        [Fact]
        public async Task Should_Create_New_Product()
        {
            Product product = await _productManager.CreateAsync("P-2", "Product-2");

            product.ShouldNotBeNull();
            product.Id.ShouldNotBe(Guid.Empty);
        }

        [Fact]
        public async Task Should_Not_Create_Already_Existing_Product()
        {
            var exception = await Assert.ThrowsAsync<ProductAlreadyExistsException>(async () =>
            {
                await _productManager.CreateAsync("P-1");
            });

            exception.Code.ShouldBe(SampleDomianErrorCodes.ProductAlreadyExists);
        }
    }
}
