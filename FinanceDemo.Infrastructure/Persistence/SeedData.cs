using FinanceDemo.Domain.Entities;

namespace FinanceDemo.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Initialize(FinanceDemoDbContext context)
        {
            if (!context.Currencies.Any())
            {
                context.Currencies.AddRange(
                    new Currency
                    {
                        Code = "BOB",
                        Descript = "Boliviano",
                        Symbol = "Bs"
                    },
                    new Currency
                    {
                        Code = "USD",
                        Descript = "US Dollar",
                        Symbol = "$"
                    }
                );
            }

            if (!context.IncomeSources.Any())
            {
                context.IncomeSources.AddRange(
                    new IncomeSource { Descript = "Salary" },
                    new IncomeSource { Descript = "Freelance" },
                    new IncomeSource { Descript = "Sale" },
                    new IncomeSource { Descript = "Investment" },
                    new IncomeSource { Descript = "Other" }
                );
            }

            if (!context.Users.Any())
            {
                context.Users.Add(
                    new User
                    {
                        FullName = "Juan Perez",
                        Email = "juan@gmail.com"
                    }
                );
            }

            context.SaveChanges();
        }
    }
}