using FinanceDemo.Application.UseCases.ExchangeRate;
using Microsoft.AspNetCore.Mvc;

namespace FinanceDemo.Api.Controllers
{
    [ApiController]
    [Route("api/exchange-rate")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly GetExchangeRateUseCase _useCase;

        public ExchangeRateController(GetExchangeRateUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _useCase.ExecuteAsync();

            return Ok(result);
        }
    }
}