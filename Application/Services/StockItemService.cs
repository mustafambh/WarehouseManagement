using AutoMapper;
using WarehouseManagement.Application.DTOs.StockItems;
using WarehouseManagement.Application.Services.Interfaces;
using WarehouseManagement.Core.Interfaces;

namespace WarehouseManagement.Application.Services
{
    public class StockItemService : IStockItemService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StockItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockItemDto>> GetAllAsync()
        {
            var StockItem = await _unitOfWork.StockItems.GetAllAsync();

            return _mapper.Map<IEnumerable<StockItemDto>>(StockItem);
        }

        public async Task<StockItemDto> GetByProductIdAsync(int id)
        {
            var StockItem = await _unitOfWork.StockItems.GetByProductIdAsync(id);

            return _mapper.Map<StockItemDto>(StockItem);
        }
    }
}
