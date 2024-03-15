using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock_API_Application.Repository;

namespace Stock_API_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPriceController : ControllerBase
    {
        private readonly IStockPriceRepository _stockPriceRepository;

        public StockPriceController(IStockPriceRepository stockPriceRepository)
        {
            this._stockPriceRepository = stockPriceRepository;
        }

        [HttpGet("get-prices/{stockId}")]
        public IActionResult FindPricesById(long stockId)
        {
            double[] prices = this._stockPriceRepository.FindPricesById(stockId);
            if(prices == null || prices.Length == 0)
                return NotFound();
            else 
                return Ok(prices);
        }
    }
}
