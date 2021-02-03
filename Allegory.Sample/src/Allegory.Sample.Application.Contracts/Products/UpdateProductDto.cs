using System.ComponentModel.DataAnnotations;

namespace Allegory.Sample.Products
{
    public class UpdateProductDto
    {
        [Required]
        [StringLength(ProductConsts.MaxCodeLength)]
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
