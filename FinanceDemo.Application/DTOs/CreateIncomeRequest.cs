namespace FinanceDemo.Application.DTOs;

public class CreateIncomeRequest
{
    /// <example>1</example>
    public int UserId { get; set; }
    /// <example>5000</example>
    public decimal Amount { get; set; }
    /// <example>December Salary</example>
    public string Description { get; set; } = string.Empty;
    public DateTime IncomeDate { get; set; }
    /// <example>1</example>
    public int CurrencyId { get; set; }
    /// <example>1</example>
    public int IncomeSourceId { get; set; }
}