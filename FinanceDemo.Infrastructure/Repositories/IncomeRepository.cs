using FinanceDemo.Application.Interfaces.Repositories;
using FinanceDemo.Domain.Entities;
using FinanceDemo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceDemo.Infrastructure.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly FinanceDemoDbContext _context;

        public IncomeRepository(FinanceDemoDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Income>> GetAllAsync()
        {
            return await _context.Income
                .Include(i => i.User)
                .Include(i => i.Currency)
                .Include(i => i.IncomeSource)
                .ToListAsync();
        }
        public async Task<Income?> GetByIdAsync(int id)
        {
            return await _context.Income
                .Include(i => i.User)
                .Include(i => i.Currency)
                .Include(i => i.IncomeSource)
                .FirstOrDefaultAsync(i => i.IncomeId == id);
        }
        public async Task<Income> CreateAsync(Income income)
        {
            _context.Income.Add(income);

            await _context.SaveChangesAsync();

            return income;
        }
        public async Task<IEnumerable<Income>> GetByPeriodAsync(int userId, DateTime startDate, DateTime endDate)
        {
            return await _context.Income
                .Include(x => x.Currency)
                .Where(x =>
                    x.UserId == userId &&
                    x.IncomeDate >= startDate &&
                    x.IncomeDate <= endDate)
                .ToListAsync();
        }
    }
}
