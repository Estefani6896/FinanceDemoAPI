namespace FinanceDemo.Application.DTOs;

public class IncomeResponse
{
    public int IncomeId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime IncomeDate { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
}