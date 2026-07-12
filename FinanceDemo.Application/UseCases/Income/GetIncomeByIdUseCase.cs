using FinanceDemo.Application.DTOs;
using FinanceDemo.Application.Interfaces.Repositories;

namespace FinanceDemo.Application.UseCases.Income;

public class GetIncomeByIdUseCase
{
    private readonly IIncomeRepository _incomeRepository;

    public GetIncomeByIdUseCase(
        IIncomeRepository incomeRepository)
    {
        _incomeRepository = incomeRepository;
    }

    public async Task<IncomeResponse?> ExecuteAsync(int id)
    {
        var income = await _incomeRepository.GetByIdAsync(id);

        if (income == null)
        {
            return null;
        }

        return new IncomeResponse
        {
            IncomeId = income.IncomeId,
            Amount = income.Amount,
            Description = income.Descript,
            IncomeDate = income.IncomeDate,
            Currency = income.Currency.Code,
            Source = income.IncomeSource.Descript,
            User = income.User.FullName
        };
    }
}