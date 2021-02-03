using Allegory.Sample.Products;
using AutoMapper;

namespace Allegory.Sample
{
    public class SampleApplicationAutoMapperProfile : Profile
    {
        public SampleApplicationAutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
