using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using WarehouseManagement.Application.Common;
using WarehouseManagement.Application.DTOs.Products;
using WarehouseManagement.Application.DTOs.StockTransactions;
using WarehouseManagement.Application.Services.Interfaces;
using WarehouseManagement.Core.Entities;
using WarehouseManagement.Core.Interfaces;

namespace WarehouseManagement.Application.Services
{
    public class StockTransactionServices : IStockTransactionServices
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public StockTransactionServices(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockTransactionDto>> GetAllAsync()
        {
            var stocktransaction = await _unitofwork.StockTransactions.GetAllAsync();

            return _mapper.Map<IEnumerable<StockTransactionDto>>(stocktransaction);
        }

        public async Task<StockTransactionDto> GetByIdAsync(int id)
        {
            var stocktransaction = await _unitofwork.StockTransactions.GetByIdAsync(id);

            return _mapper.Map<StockTransactionDto>(stocktransaction);
        }

        public async Task<ServiceResult<StockTransactionDto>> CreateAsync(StockTransactionCreateDto dto)
        {
            var product = await _unitofwork.Products.GetByIdAsync(dto.ProductId);

            if (product == null)
            {
                return new ServiceResult<StockTransactionDto>
                {
                    Success = false,
                    Error = $"Product Id Not Found {dto.ProductId}",
                    Number = 404,
                };
            }

            if (dto.SupplierId != null)
            {
                var supplier = await _unitofwork.Suppliers.GetByIdAsync(dto.SupplierId.Value);

                if (supplier == null)
                {
                    return new ServiceResult<StockTransactionDto>
                    {
                        Success = false,
                        Error = $"Supplier Id Not Found {dto.SupplierId}",
                        Number = 404
                    };
                }
            }

            if (dto.Quantity <= 0)
            {
                return new ServiceResult<StockTransactionDto>
                {
                    Success = false,
                    Error = "Quantity must be greater than zero",
                    Number = 400
                };
            }

            var stockitem = await _unitofwork.StockItems.GetByProductIdAsync(dto.ProductId);

            if (stockitem == null)
            {
                return new ServiceResult<StockTransactionDto>
                {
                    Success = false,
                    Error = "StockItem not found for this product",
                    Number = 404
                };
            }

            if (dto.TransactionType == "IN")
            {
                stockitem.Quantity += dto.Quantity;
            }
            else if (dto.TransactionType == "OUT")
            {
                if (dto.Quantity > stockitem.Quantity)
                {
                    return new ServiceResult<StockTransactionDto>
                    {
                        Success = false,
                        Error = $"Requested quantity is greater than available quantity ({stockitem.Quantity})",
                        Number = 400,
                    };
                }

                stockitem.Quantity -= dto.Quantity;
            }
            else
            {
                return new ServiceResult<StockTransactionDto>
                {
                    Success = false,
                    Error = "TransactionType must be IN or OUT",
                    Number = 400
                };
            }

            stockitem.LastUpdated = DateTime.UtcNow;

            var stocktransaction = _mapper.Map<StockTransaction>(dto);
            stocktransaction.CreatedAt = DateTime.UtcNow;

            await _unitofwork.StockTransactions.AddAsync(stocktransaction);
            await _unitofwork.SaveChangesAsync();

            return new ServiceResult<StockTransactionDto>
            {
                Success = true,
                Data = _mapper.Map<StockTransactionDto>(stocktransaction),
                Number = 200
            };
        }

    }
}

