using AutoMapper;
using WarehouseManagement.Application.DTOs.Suppliers;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Application.Mappings
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            // Entity → DTO
            CreateMap<Supplier, SupplierDto>();

            // CreateDTO → Entity
            CreateMap<SupplierCreateDto, Supplier>();

            // UpdateDTO → Entity
            CreateMap<SupplierUpdateDto, Supplier>();
        }
    }
}
