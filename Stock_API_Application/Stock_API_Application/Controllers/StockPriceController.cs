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
            dynamic result = this._stockPriceRepository.FindPricesById(stockId);
            if(result == null || result.stockName == null)
                return NotFound("Stock does not exist.");
            else 
                return Ok(result);
        }

        [HttpGet("get-prices")]
        public IActionResult FindPricesByIdAndDate([FromQuery(Name = "id")]long stockId,[FromQuery] DateOnly date) 
        {
            List<dynamic> result = this._stockPriceRepository.FindPricesByIdAndDate(stockId, date);
            if (result.Count == 0) 
                return NotFound("No such record for the given date.");
            else 
                return Ok(result);
        }
    }
}
