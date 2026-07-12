using FinanceDemo.Application.DTOs;
using FinanceDemo.Application.Interfaces.Repositories;
using FinanceDemo.Application.Interfaces.Services;

namespace FinanceDemo.Application.UseCases.Reports
{
    public class GetConsolidatedBalanceUseCase
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExchangeRateService _exchangeRateService;

        public GetConsolidatedBalanceUseCase(
            IIncomeRepository incomeRepository,
            IExchangeRateService exchangeRateService)
        {
            _incomeRepository = incomeRepository;
            _exchangeRateService = exchangeRateService;
        }

        public async Task<ConsolidatedBalanceResponse> ExecuteAsync(
            ConsolidatedBalanceRequest request)
        {
            var incomes = await _incomeRepository.GetByPeriodAsync(
                request.UserId,
                request.StartDate,
                request.EndDate);

            var exchangeRate =
                await _exchangeRateService.GetExchangeRateAsync();

            decimal total = 0;

            foreach (var income in incomes)
            {
                var currency = income.Currency.Code;

                if (request.TargetCurrency == "BOB")
                {
                    if (currency == "BOB")
                    {
                        total += income.Amount;
                    }
                    else if (currency == "USD")
                    {
                        total += income.Amount * exchangeRate;
                    }
                }
                else if (request.TargetCurrency == "USD")
                {
                    if (currency == "USD")
                    {
                        total += income.Amount;
                    }
                    else if (currency == "BOB")
                    {
                        total += income.Amount / exchangeRate;
                    }
                }
            }

            return new ConsolidatedBalanceResponse
            {
                UserId = request.UserId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Currency = request.TargetCurrency,
                ExchangeRate = exchangeRate,
                TotalBalance = Math.Round(total, 2)
            };
        }
    }
}