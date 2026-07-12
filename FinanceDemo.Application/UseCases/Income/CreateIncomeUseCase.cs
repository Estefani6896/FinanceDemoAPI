using FinanceDemo.Application.DTOs;
using FinanceDemo.Application.Interfaces.Repositories;
using FinanceDemo.Domain.Entities;
namespace FinanceDemo.Application.UseCases.Income;
public class CreateIncomeUseCase
{
    private readonly IIncomeRepository _incomeRepository;

    public CreateIncomeUseCase(IIncomeRepository incomeRepository)
    {
        _incomeRepository = incomeRepository;
    }
    public async Task<int> ExecuteAsync(CreateIncomeRequest request)
    {
        if (request.Amount <= 0)
        {
            throw new Exception("Amount must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new Exception("Description is required.");
        }
        if (request.CurrencyId != 1 && request.CurrencyId != 2)
        {
            throw new Exception("Currency not supported.");
        }
        var income = new Domain.Entities.Income
        {
            UserId = request.UserId,
            Amount = request.Amount,
            Descript = request.Description,
            IncomeDate = request.IncomeDate,
            CurrencyId = request.CurrencyId,
            IncomeSourceId = request.IncomeSourceId,
            CreatedAt = DateTime.UtcNow
        };

        var savedIncome = await _incomeRepository.CreateAsync(income);

        return savedIncome.IncomeId;
    }
}