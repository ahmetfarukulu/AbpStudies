using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Allegory.Sample.Products;
using Allegory.Standart.Filter.Concrete;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Allegory.Sample.Controllers
{
    [ControllerName("Product")]
    [Route("api/sample/products")]
    public class ProductController : AbpController, IProductAppService
    {
        protected IProductAppService ProductAppService { get; }

        public ProductController(IProductAppService productAppService)
        {
            ProductAppService = productAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ProductDto> GetAsync(Guid id) => ProductAppService.GetAsync(id);

        [HttpGet]
        public Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input) => ProductAppService.GetListAsync(input);

        [HttpPost]
        [Route("by-condition")]
        public Task<List<ProductDto>> GetListByConditionAsync(Condition condition) => ProductAppService.GetListByConditionAsync(condition);

        [HttpPost]
        [Route("by-dynamic-linq/{predicate}")]
        public Task<List<ProductDto>> GetListByDynamicLinqAsync(string predicate, [FromBody] params object[] args) => ProductAppService.GetListByDynamicLinqAsync(predicate, args);

        [HttpPost]
        public Task<ProductDto> CreateAsync(CreateProductDto input) => ProductAppService.CreateAsync(input);

        [HttpPut]
        [Route("{id}")]
        public Task UpdateAsync(Guid id, UpdateProductDto input) => ProductAppService.UpdateAsync(id, input);

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id) => ProductAppService.DeleteAsync(id);
    }
}
