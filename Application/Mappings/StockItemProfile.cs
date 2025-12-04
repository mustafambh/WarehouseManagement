using AutoMapper;
using WarehouseManagement.Application.DTOs.StockItems;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Application.Mappings
{
    public class StockItemProfile : Profile
    {
        public StockItemProfile()
        {
            // Entity → DTO
            CreateMap<StockItem, StockItemDto>()
                .ForMember(dest => dest.ProductName,
                           opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
