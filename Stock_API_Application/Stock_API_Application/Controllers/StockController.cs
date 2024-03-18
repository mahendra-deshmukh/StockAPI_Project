using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
            if(list == null || list.Count == 0) 
                return NotFound("Stock not found.");
            else
                return Ok(list);
        }

        [HttpGet("{parameter}")]
        public IActionResult FindByParameter(String parameter)
        {
            Stock stock = null;
            if (string.IsNullOrEmpty(parameter))
                return BadRequest("There should be some value for the parameter.");
            if (long.TryParse(parameter, out long number))
            {
                stock = this._stockRepository.FindById(number);
            }
            else
                stock = this._stockRepository.FindByName(parameter);
            if (stock == null)
                return NotFound("Stock not found.");
            else
                return Ok(stock);
        }

        [HttpGet("pattern/{pattern}")]
        public IActionResult FindByInitialPattern(String pattern)
        {
            List<Stock> list = this._stockRepository.FindByInitialPattern(pattern);
            if (list == null || list.Count() == 0)
                return NotFound("Stock not found.");
            else 
                return Ok(list);
        }
    }
}
