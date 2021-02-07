using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allegory.Standart.Filter.Concrete;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Allegory.Sample.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> GetAsync(Guid id);

        Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input);

        Task<List<ProductDto>> GetListByConditionAsync(Condition condition);

        Task<List<ProductDto>> GetListByDynamicLinqAsync(string predicate, params object[] args);

        Task<ProductDto> CreateAsync(CreateProductDto input);

        Task UpdateAsync(Guid id, UpdateProductDto input);

        Task DeleteAsync(Guid id);
    }
}
