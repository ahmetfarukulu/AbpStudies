using System;
using Volo.Abp.Application.Dtos;

namespace Allegory.Sample.Products
{
    public class ProductDto : EntityDto<Guid>
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
