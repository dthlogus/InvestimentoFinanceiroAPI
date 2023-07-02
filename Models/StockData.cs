using Newtonsoft.Json;

namespace API_Financeira.Models
{
    public class StockData
    {
        [JsonProperty("priceToBook")]
        public double PriceToBook { get; set; }

        [JsonProperty("regularMarketPrice")]
        public double RegularMarketPrice { get; set; }

        [JsonProperty("trailingAnnualDividendYield")]
        public double TrailingAnnualDividendYield { get; set; }

        [JsonProperty("epsTrailingTwelveMonths")]
        public double EpsTrailingTwelveMonths { get; set; }

        [JsonProperty("bookValue")]
        public double BookValue { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("longName")]
        public string LongName { get; set; }
    }
}
