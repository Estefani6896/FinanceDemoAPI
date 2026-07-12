using FinanceDemo.Application.DTOs;
using FinanceDemo.Application.Interfaces.Services;
using FinanceDemo.Infrastructure.Models;
using System.Net.Http.Json;

namespace FinanceDemo.Infrastructure.Services
{
    public class HexaRateService : IExchangeRateService
    {
        private readonly HttpClient _httpClient;

        public HexaRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ExchangeRateResponse> GetUsdToBobRateAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<HexaRateResponseModel>(
                    "https://hexarate.paikama.co/api/rates/USD/BOB/latest");

                if (response == null)
                {
                    throw new Exception("Exchange rate service returned null.");
                }

                return new ExchangeRateResponse
                {
                    BaseCurrency = response.Data.Base,
                    TargetCurrency = response.Data.Target,
                    Rate = response.Data.Mid,
                    Unit = response.Data.Unit,
                    Timestamp = response.Data.Timestamp
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HexaRate Error: {ex.Message}");

                // Fallback para Render cuando HexaRate devuelve 403
                return new ExchangeRateResponse
                {
                    BaseCurrency = "USD",
                    TargetCurrency = "BOB",
                    Rate = 10.215m,
                    Unit = 1,
                    Timestamp = DateTime.UtcNow
                };
            }
        }
        public async Task<decimal> GetExchangeRateAsync()
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<HexaRateResponseModel>(
                        "https://hexarate.paikama.co/api/rates/USD/BOB/latest");

                if (response == null)
                    throw new Exception();

                return response.Data.Mid;
            }
            catch
            {
                // fallback para entornos donde HexaRate es bloqueado
                return 10.215m;
            }
        }
    }
}