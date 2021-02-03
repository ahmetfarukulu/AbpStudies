using System;
using System.Threading.Tasks;
using Allegory.Sample.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Allegory.Sample
{
    public class SampleDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        IRepository<Product, Guid> _productRepository;
        ProductManager _productManager;
        public SampleDataSeederContributor(IRepository<Product, Guid> productRepository, ProductManager productManager)
        {
            _productRepository = productRepository;
            _productManager = productManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _productRepository.GetCountAsync() > 0)
                return;

            await _productRepository.InsertAsync
            (
                await _productManager.CreateAsync
                (
                    "P-1",
                    "Product 1"
                ),
                autoSave: true
            );
        }
    }
}
