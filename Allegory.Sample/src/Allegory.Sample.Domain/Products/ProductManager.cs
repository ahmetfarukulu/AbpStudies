using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Allegory.Sample.Products
{
    public class ProductManager : DomainService
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductManager(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateAsync([NotNull] string code, [CanBeNull] string name = null)
        {
            var existingProduct = await _productRepository.FindAsync(p => p.Code == code);
            if (existingProduct != null)
            {
                throw new ProductAlreadyExistsException(code);
            }

            return new Product(GuidGenerator.Create(), code, name);
        }
        public async Task ChangeCodeAsync([NotNull] Product product, [NotNull] string newCode)
        {
            var existingProduct = await _productRepository.FindAsync(p => p.Code == newCode);
            if (existingProduct != null && existingProduct.Id != product.Id)
            {
                throw new ProductAlreadyExistsException(newCode);
            }

            product.ChangeCode(newCode);
        }
    }
}
