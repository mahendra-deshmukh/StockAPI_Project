using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock_API_Application.Model;
using Stock_API_Application.Repository;

namespace Stock_API_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRespository _stockRepository;

        public StockController(IStockRespository stockRespository)
        {
            this._stockRepository = stockRespository;
        }

        [HttpGet("get-all")]
        public IActionResult getAllStocks() {
            List<Stock> list = this._stockRepository.getAll();
            return Ok(list);
        }

        [HttpGet("{stockId}")]
        public IActionResult findById(long stockId)
        {
            Stock stock = this._stockRepository.findById(stockId);
            if(stock!=null)
                return Ok(stock);
            else
                return BadRequest();
        }
    }
}
