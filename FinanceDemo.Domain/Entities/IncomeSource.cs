namespace FinanceDemo.Domain.Entities
{
    public class IncomeSource
    {
        public int IncomeSourceId { get; set; }
        public string Descript { get; set; } = string.Empty;
        public ICollection<Income> Incomes { get; set; }
            = new List<Income>();
    }
}