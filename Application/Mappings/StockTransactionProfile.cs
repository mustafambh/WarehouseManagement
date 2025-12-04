using AutoMapper;
using WarehouseManagement.Application.DTOs.StockTransactions;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Application.Mappings
{
    public class StockTransactionProfile : Profile
    {
        public StockTransactionProfile()
        {
            // Entity → DTO
            CreateMap<StockTransaction, StockTransactionDto>()
                .ForMember(dest => dest.ProductName,
                           opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.SupplierName,
                           opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : null));

            // CreateDTO → Entity
            CreateMap<StockTransactionCreateDto, StockTransaction>();
        }
    }
}
