using FinanceDemo.Application.DTOs;
using FinanceDemo.Application.UseCases.Reports;
using Microsoft.AspNetCore.Mvc;

namespace FinanceDemo.Api.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly GetConsolidatedBalanceUseCase _useCase;

        public ReportsController(
            GetConsolidatedBalanceUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("consolidated-balance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBalance(
            ConsolidatedBalanceRequest request)
        {
            var result =
                await _useCase.ExecuteAsync(request);

            return Ok(result);
        }
    }
}