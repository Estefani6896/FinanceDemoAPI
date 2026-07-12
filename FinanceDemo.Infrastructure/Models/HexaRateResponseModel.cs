namespace FinanceDemo.Infrastructure.Models;

public class HexaRateResponseModel
{
    public int Status_Code { get; set; }
    public HexaRateData Data { get; set; } = new();
}