using AutoMapper;
using WarehouseManagement.Application.DTOs.Products;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Entity → DTO (لـ GET)
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name));

            // CreateDTO → Entity (لـ POST)
            CreateMap<ProductCreateDto, Product>();

            // UpdateDTO → Entity (لـ PUT/PATCH)
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
