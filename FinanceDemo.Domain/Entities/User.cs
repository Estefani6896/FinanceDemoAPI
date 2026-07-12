namespace FinanceDemo.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public ICollection<Income> Incomes { get; set; }
            = new List<Income>();
    }
}