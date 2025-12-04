using AutoMapper;
using WarehouseManagement.Application.DTOs.Categories;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Entity → DTO
            CreateMap<Category, CategoryDto>();

            // CreateDTO → Entity
            CreateMap<CategoryCreateDTO, Category>();

            // UpdateDTO → Entity
            CreateMap<CategoryUpdateDTO, Category>();
        }
    }
}
