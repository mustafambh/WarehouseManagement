using WarehouseManagement.Application.Common;
using WarehouseManagement.Application.DTOs.Categories;
using WarehouseManagement.Application.DTOs.Products;

namespace WarehouseManagement.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ServiceResult<ProductDto>> CreateAsync(ProductCreateDto dto);
        Task<ServiceResult> UpdateAsync(int id, ProductUpdateDto dto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
