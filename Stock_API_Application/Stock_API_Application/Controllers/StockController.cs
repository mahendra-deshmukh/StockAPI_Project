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
        public IActionResult GetAllStocks() {
            List<Stock> list = this._stockRepository.GetAll();
            return Ok(list);
        }

        [HttpGet("id/{stockId}")]
        public IActionResult FindById(long stockId)
        {
            Stock stock = this._stockRepository.FindById(stockId);
            if(stock!=null)
                return Ok(stock);
            else
                return BadRequest();
        }

        [HttpGet("name/{stockName}")]
        public IActionResult FindByName(string stockName)
        {
            Stock stock = this._stockRepository.FindByName(stockName);
            if(stock!=null)
                return Ok(stock);
            else 
                return BadRequest();
        }

        [HttpGet("pattern/{pattern}")]
        public IActionResult FindByInitialPattern(String pattern)
        {
            List<Stock> list = this._stockRepository.FindByInitialPattern(pattern);
            if (list == null || list.Count() == 0)
                return NotFound();
            else 
                return Ok(list);
        }
    }
}
