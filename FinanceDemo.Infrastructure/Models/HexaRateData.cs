namespace FinanceDemo.Infrastructure.Models;

public class HexaRateData
{
    public string Base { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public decimal Mid { get; set; }
    public int Unit { get; set; }
    public DateTime Timestamp { get; set; }
}