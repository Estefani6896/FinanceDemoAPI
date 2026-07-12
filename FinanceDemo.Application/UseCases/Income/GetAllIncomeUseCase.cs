using FinanceDemo.Application.DTOs;
using FinanceDemo.Application.Interfaces.Repositories;

namespace FinanceDemo.Application.UseCases.Income;

public class GetAllIncomeUseCase
{
    private readonly IIncomeRepository _incomeRepository;

    public GetAllIncomeUseCase(IIncomeRepository incomeRepository)
    {
        _incomeRepository = incomeRepository;
    }

    public async Task<IEnumerable<IncomeResponse>> ExecuteAsync()
    {
        var incomes = await _incomeRepository.GetAllAsync();

        return incomes.Select(i => new IncomeResponse
        {
            IncomeId = i.IncomeId,
            Amount = i.Amount,
            Description = i.Descript,
            IncomeDate = i.IncomeDate,
            Currency = i.Currency.Code,
            Source = i.IncomeSource.Descript,
            User = i.User.FullName
        });
    }
}