using FinanceDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceDemo.Application.Interfaces.Repositories
{
    public interface IIncomeRepository
    {
        Task<Income> CreateAsync(Income income);
        Task<IEnumerable<Income>> GetAllAsync();
        Task<Income?> GetByIdAsync(int id);
        Task<IEnumerable<Income>> GetByPeriodAsync(int userId, DateTime startDate, DateTime endDate);
    }
}
