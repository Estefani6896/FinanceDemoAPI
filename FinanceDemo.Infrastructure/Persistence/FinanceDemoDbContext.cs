using FinanceDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceDemo.Infrastructure.Persistence
{
    public class FinanceDemoDbContext : DbContext
    {
        public FinanceDemoDbContext(
            DbContextOptions<FinanceDemoDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Income> Income => Set<Income>();
        public DbSet<Currency> Currencies => Set<Currency>();
        public DbSet<IncomeSource> IncomeSources => Set<IncomeSource>();
    }
}
