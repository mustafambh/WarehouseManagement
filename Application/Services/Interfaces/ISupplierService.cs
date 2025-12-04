using WarehouseManagement.Application.Common;
using WarehouseManagement.Application.DTOs.Products;
using WarehouseManagement.Application.DTOs.Suppliers;

namespace WarehouseManagement.Application.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>> GetAllAsync();
        Task<SupplierDto> GetByIdAsync(int id);
        Task<SupplierDto> CreateAsync(SupplierCreateDto dto);
        Task<ServiceResult> UpdateAsync(int id, SupplierUpdateDto dto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
