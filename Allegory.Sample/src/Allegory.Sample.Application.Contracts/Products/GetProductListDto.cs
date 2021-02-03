using Volo.Abp.Application.Dtos;

namespace Allegory.Sample.Products
{
    public class GetProductListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
