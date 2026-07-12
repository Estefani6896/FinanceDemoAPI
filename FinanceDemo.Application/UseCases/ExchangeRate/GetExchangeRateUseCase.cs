using FinanceDemo.Application.DTOs;
using FinanceDemo.Application.Interfaces.Services;

namespace FinanceDemo.Application.UseCases.ExchangeRate
{
    public class GetExchangeRateUseCase
    {
        private readonly IExchangeRateService _exchangeRateService;

        public GetExchangeRateUseCase(
            IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public async Task<ExchangeRateResponse> ExecuteAsync()
        {
            return await _exchangeRateService.GetUsdToBobRateAsync();
        }
    }
}