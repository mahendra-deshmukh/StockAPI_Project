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
            var list = this._stockRepository.getAll();
            return Ok(list);
        }
    }
}
