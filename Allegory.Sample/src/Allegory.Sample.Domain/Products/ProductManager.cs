using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Allegory.Sample.Products
{
    public class ProductManager : DomainService
    {
        public ProductManager()
        {

        }

        public async Task<Product> CreateAsync([NotNull] string code, [CanBeNull] string name=null)
        {
            Logger.Log(LogLevel.Information, "ProductManager.CreateAsync worked");

            return new Product(GuidGenerator.Create(), code, name);
        }
        public async Task ChangeCodeAsync([NotNull] Product product,[NotNull] string newCode)
        {
            Check.NotNull(product, nameof(product));

            product.ChangeCode(newCode);
        }
    }
}
