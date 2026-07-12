using FinanceDemo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceDemo.Application.Interfaces.Services
{
    public interface IExchangeRateService
    {
        Task<ExchangeRateResponse> GetUsdToBobRateAsync();
        Task<decimal> GetExchangeRateAsync();
    }
}
