namespace FinanceDemo.Application.DTOs
{
    public class ConsolidatedBalanceResponse
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Currency { get; set; } = string.Empty;
        public decimal ExchangeRate { get; set; }
        public decimal TotalBalance { get; set; }
    }
}