namespace FinanceDemo.Domain.Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Descript { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public ICollection<Income> Incomes { get; set; }
            = new List<Income>();
    }
}