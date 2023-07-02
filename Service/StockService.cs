using API_Financeira.DTO;
using API_Financeira.Models;
using Newtonsoft.Json;
using AutoMapper;

namespace API_Financeira.Service
{
    public class StockService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public StockService(IMapper mapper)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "dddcf7a2b2mshbbd05839cc265e0p1c7087jsn76cc414c5a76");
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "yahoo-finance15.p.rapidapi.com");

            _mapper = mapper;
        }

        public async Task<List<StockDTO>> FindStockData(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<StockData> stockData = JsonConvert.DeserializeObject<List<StockData>>(responseBody);
            List<StockDTO> stockDTO = _mapper.Map<List<StockData>, List<StockDTO>>(stockData);

            return stockDTO;
        }
    }
}
