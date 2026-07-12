namespace FinanceDemo.Application.DTOs
{
    public class ExchangeRateResponse
    {
        public string BaseCurrency { get; set; } = string.Empty;
        public string TargetCurrency { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public int Unit { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
