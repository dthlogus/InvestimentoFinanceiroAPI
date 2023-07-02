using API_Financeira.DTO;
using API_Financeira.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Financeira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("{symbol}")]
        public async Task<ActionResult<List<StockDTO>>> GetStockData(string symbol)
        {
            try
            {
                string apiURL = $"https://yahoo-finance15.p.rapidapi.com/api/yahoo/qu/quote/{symbol}";
                List<StockDTO> stockDTOs = await _stockService.FindStockData(apiURL);

                if (stockDTOs.Count == 0)
                    return NoContent(); 

                return Ok(stockDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter os dados da ação");
            }
        }
    }
}
