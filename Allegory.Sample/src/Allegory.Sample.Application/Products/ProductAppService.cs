using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Allegory.Sample.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Allegory.Sample.Products
{
    [RemoteService(false)]
    [Authorize(SamplePermissions.Products.Default)]
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly ProductManager _productManager;
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductAppService(ProductManager productManager, IRepository<Product, Guid> productRepository)
        {
            _productManager = productManager;
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
                input.Sorting = nameof(Product.Code);

            var queryable = await _productRepository.GetQueryableAsync();

            var query = queryable.WhereIf
                                 (
                                     !input.Filter.IsNullOrWhiteSpace(),
                                     product => product.Code.Contains(input.Filter)
                                 )
                                 .OrderBy(input.Sorting)
                                 .PageBy(input.SkipCount, input.MaxResultCount);

            var products = await AsyncExecuter.ToListAsync(query);

            int totalCount = await AsyncExecuter.CountAsync(queryable.WhereIf
                                 (
                                     !input.Filter.IsNullOrWhiteSpace(),
                                     product => product.Code.Contains(input.Filter)
                                 ));

            return new PagedResultDto<ProductDto>(
               totalCount,
               ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
           );
        }

        [Authorize(SamplePermissions.Products.Create)]
        public async Task<ProductDto> CreateAsync(CreateProductDto input)
        {
            var product = await _productManager.CreateAsync(input.Code, input.Name);

            await _productRepository.InsertAsync(product);

            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        [Authorize(SamplePermissions.Products.Edit)]
        public async Task UpdateAsync(Guid id, UpdateProductDto input)
        {
            var product = await _productRepository.GetAsync(id);

            if (product.Code != input.Code)
            {
                await _productManager.ChangeCodeAsync(product, input.Code);
            }

            product.Name = input.Name;

            await _productRepository.UpdateAsync(product);
        }

        [Authorize(SamplePermissions.Products.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
