namespace FinanceDemo.Application.DTOs
{
    public class ConsolidatedBalanceRequest
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TargetCurrency { get; set; } = string.Empty;
    }
}