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
            var response =
                await _httpClient.GetFromJsonAsync<HexaRateResponseModel>(
                    "https://hexarate.paikama.co/api/rates/USD/BOB/latest");

            if (response == null)
            {
                throw new Exception("Exchange rate service unavailable.");
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
        public async Task<decimal> GetExchangeRateAsync()
        {
            var httpResponse = await _httpClient.GetAsync(
                "https://hexarate.paikama.co/api/rates/USD/BOB/latest");

            var content = await httpResponse.Content.ReadAsStringAsync();

            Console.WriteLine($"Status: {httpResponse.StatusCode}");
            Console.WriteLine($"Content: {content}");

            httpResponse.EnsureSuccessStatusCode();

            var response = System.Text.Json.JsonSerializer.Deserialize<HexaRateResponseModel>(
                content,
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (response == null)
            {
                throw new Exception("Exchange rate unavailable.");
            }

            return response.Data.Mid;
        }
    }
}