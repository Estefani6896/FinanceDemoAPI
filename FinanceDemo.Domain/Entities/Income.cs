using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceDemo.Domain.Entities
{
    public class Income
    {
        public int IncomeId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Descript { get; set; } = string.Empty;
        public DateTime IncomeDate { get; set; }
        public int CurrencyId { get; set; }
        public int IncomeSourceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Currency Currency { get; set; } = null!;
        public User User { get; set; } = null!;
        public IncomeSource IncomeSource { get; set; } = null!;
    }
}
