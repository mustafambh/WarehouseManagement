using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Common;
using WarehouseManagement.Application.DTOs.Categories;
using WarehouseManagement.Application.DTOs.Products;
using WarehouseManagement.Application.DTOs.StockItems;
using WarehouseManagement.Application.Services.Interfaces;
using WarehouseManagement.Core.Entities;
using WarehouseManagement.Core.Interfaces;
using WarehouseManagement.Infrastructure;

namespace WarehouseManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

             if (product == null)
                return null;

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ServiceResult<ProductDto>> CreateAsync(ProductCreateDto dto)
        {
            if (await _unitOfWork.Products.CheckTheSKU(dto.SKU))
            {
                return new ServiceResult<ProductDto>
                {
                    Success = false,
                    Error = "Product with this SKU already exists",
                    Number = 409
                };
            }

            var category = await _unitOfWork.Categories.GetByIdAsync(dto.CategoryId);
            if (category == null)
            {
                return new ServiceResult<ProductDto>
                {
                    Success = false,
                    Error = $"Category Id Not Found {dto.CategoryId}",
                    Number = 404
                };
            }

            var product = _mapper.Map<Product>(dto);
            product.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.Products.AddAsync(product);

            var stockItem = new StockItem
            {
                Product = product,
                Quantity = 0,
                LastUpdated = DateTime.UtcNow
            };

            await _unitOfWork.StockItems.AddAsync(stockItem);

            await _unitOfWork.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return new ServiceResult<ProductDto>
            {
                Success = true,
                Data = productDto,
                Number = 200
            };
        }


        public async Task<ServiceResult> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Error = $"Product Id Not Found {dto.CategoryId}",
                    Number = 404
                };
            }

            if (dto.SKU != product.SKU && await _unitOfWork.Products.CheckTheSKU(dto.SKU))
                return new ServiceResult
                {
                    Success = false,
                    Error = "Product with this SKU already exists",
                    Number = 409
                };

            var category = await _unitOfWork.Categories.GetByIdAsync(dto.CategoryId);
            if (category == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Error = $"Category Id Not Found {dto.CategoryId}",
                    Number = 404
                };
            }

            _mapper.Map(dto, product);

            _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResult
            {
                Success = true,
                Error = "Update Data",
                Number = 200
            };
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Error = $"Product Id Not Found {id}",
                    Number = 404
                };
            }

            _unitOfWork.Products.DeleteAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResult
            {
                Success = true,
                Error = "Delete Data", 
                Number = 200
            };
        }
    }
}
