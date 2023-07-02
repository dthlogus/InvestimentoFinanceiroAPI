namespace API_Financeira.DTO
{
    public class StockDTO
    {
        public double PVP { get; set; }
        public double PV { get; set; }
        public double DY { get; set; }
        public double VPA { get; set; }
        public double LPA { get; set; }
        public string Symbol { get; set; }
        public string LongName { get; set; }
    }
}
