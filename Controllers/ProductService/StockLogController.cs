using ECommerceBackend.Models.ProductService.Enum;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.Controllers.ProductService
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockLogController : ControllerBase
    {
        private readonly IStockLogServiceRep _stockLogService;

        public StockLogController(IStockLogServiceRep stockLogService)
        {
            _stockLogService = stockLogService;
        }

        [HttpPost("log")]
        public async Task<IActionResult> LogStockChange(int productId, int changeAmount, StockChangeReason reason, string? reference = null)
        {
            await _stockLogService.LogAsync(productId, changeAmount, reason, reference);
            return Ok(new { message = "Log stock change successfully." });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _stockLogService.GetAllLogsAsync();
            return Ok(logs);
        }

        [HttpGet("by-product/{productId}")]
        public async Task<IActionResult> GetLogsByProduct(int productId)
        {
            var logs = await _stockLogService.GetLogsByProductAsync(productId);
            return Ok(logs);
        }
    }
}
