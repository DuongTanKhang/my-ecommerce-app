using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.Enum;
using ECommerceBackend.Repositories;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerceBackend.Services
{
    public class StockLogServiceRep : IStockLogServiceRep
    {
        private IUnitOfWork _unitOfWork;

        public StockLogServiceRep(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task LogAsync(int productId, int changeAmount, StockChangeReason reason, string? reference = null)
        {
            string note = reason switch
            {
                StockChangeReason.NhapKho => $"Nhập kho{(reference != null ? $" - {reference}" : "")}",
                StockChangeReason.BanHang => $"Bán hàng{(reference != null ? $" - Đơn: {reference}" : "")}",
                StockChangeReason.HuyDon => $"Hủy đơn{(reference != null ? $" - Đơn: {reference}" : "")}",
                StockChangeReason.DieuChinh => "Điều chỉnh tồn kho thủ công",
                StockChangeReason.TraHang => $"Trả hàng{(reference != null ? $" - Đơn: {reference}" : "")}",
                StockChangeReason.KiemKho => "Điều chỉnh theo kiểm kho",
                _ => $"Thay đổi tồn kho: {changeAmount}"
            };
            var log = new TblStockLog
            {
                ProductId = productId,
                ChangeAmount = changeAmount,
                Note = note

            };

            await _unitOfWork.StockLogRepository.Add(log);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<IEnumerable<TblStockLog?>> GetAllLogsAsync()
        {
            return await _unitOfWork.StockLogRepository.GetAll();
        }

        public async Task<IEnumerable<TblStockLog>> GetLogsByProductAsync(int productId)
        {
            return await _unitOfWork.StockLogRepository.GetByProductIdAsync(productId);
        }
    }
}
