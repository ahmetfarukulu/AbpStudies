using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Validation;
using Xunit;

namespace Allegory.Sample.Products
{
    public class ProductAppService_Tests : SampleApplicationTestBase
    {
        private readonly IProductAppService _productAppService;

        public ProductAppService_Tests()
        {
            _productAppService = GetRequiredService<IProductAppService>();
        }

        [Fact]
        public async Task Should_Not_Create_A_Product_Without_Code()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _productAppService.CreateAsync(
                    new CreateProductDto
                    {
                        Code = ""
                    }
                );
            });

            exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(m => m == "Code"));
        }

        [Fact]
        public async Task Should_Create_A_Valid_Product()
        {
            var result = await _productAppService.CreateAsync(
                new CreateProductDto
                {
                  Code="P-2",
                  Name="Product-2"
                }
            );

            result.Id.ShouldNotBe(Guid.Empty);
            result.Code.ShouldBe("P-2");
        }
    }
}
