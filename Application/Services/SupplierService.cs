using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.JSInterop.Infrastructure;
using WarehouseManagement.Application.Common;
using WarehouseManagement.Application.DTOs.Suppliers;
using WarehouseManagement.Application.Services.Interfaces;
using WarehouseManagement.Core.Entities;
using WarehouseManagement.Core.Interfaces;

namespace WarehouseManagement.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public SupplierService(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var supplier = await _unitofwork.Suppliers.GetAllAsync();

            return _mapper.Map<IEnumerable<SupplierDto>>(supplier);
        }

        public async Task<SupplierDto> GetByIdAsync(int id)
        {
            var supplier = await _unitofwork.Suppliers.GetByIdAsync(id);

            return _mapper.Map<SupplierDto>(supplier);
        }

        public async Task<SupplierDto> CreateAsync(SupplierCreateDto dto)
        {
            var supplier = _mapper.Map<Supplier>(dto);

            await _unitofwork.Suppliers.AddAsync(supplier);
            await _unitofwork.SaveChangesAsync();

            return _mapper.Map<SupplierDto>(supplier);
        }

        public async Task<ServiceResult> UpdateAsync(int id, SupplierUpdateDto dto)
        {
            var supplier = await _unitofwork.Suppliers.GetByIdAsync(id);

            if (supplier == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Error = $"Supplier Id Not Found {id}",
                    Number = 404
                };
            }

            _mapper.Map(dto , supplier);

            _unitofwork.Suppliers.UpdateAsync(supplier);
            await _unitofwork.SaveChangesAsync();

            return new ServiceResult
            {
                Success = true,
                Error = "Data Update",
                Number = 200
            };
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var supplier = await _unitofwork.Suppliers.GetByIdAsync(id);

            if (supplier == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Error = $"Supplier Id Not Found {id}",
                    Number = 404
                };
            }

            _unitofwork.Suppliers.DeleteAsync(supplier);
            await _unitofwork.SaveChangesAsync();

            return new ServiceResult
            {
                Success = true,
                Error = "Data Delete",
                Number = 200
            };
        }
    }
}
