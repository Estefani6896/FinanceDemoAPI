using FinanceDemo.Application.DTOs;
using FinanceDemo.Application.UseCases.Income;
using Microsoft.AspNetCore.Mvc;

namespace FinanceDemo.Api.Controllers;

[ApiController]
[Route("api/incomes")]
public class IncomeController : ControllerBase
{
    private readonly CreateIncomeUseCase _createIncomeUseCase;
    private readonly GetAllIncomeUseCase _getAllIncomeUseCase;
    private readonly GetIncomeByIdUseCase _getIncomeByIdUseCase;
    public IncomeController(CreateIncomeUseCase createIncomeUseCase, GetAllIncomeUseCase getAllIncomeUseCase, GetIncomeByIdUseCase getIncomeByIdUseCase)
    {
        _createIncomeUseCase = createIncomeUseCase;
        _getAllIncomeUseCase = getAllIncomeUseCase;
        _getIncomeByIdUseCase = getIncomeByIdUseCase;
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateIncomeRequest request)
    {
        var incomeId =
            await _createIncomeUseCase.ExecuteAsync(request);

        return Created("", new
        {
            IncomeId = incomeId,
            Message = "Income registered successfully"
        });
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var incomes = await _getAllIncomeUseCase.ExecuteAsync();

        return Ok(incomes);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var income = await _getIncomeByIdUseCase.ExecuteAsync(id);

        if (income == null)
        {
            return NotFound(new
            {
                Message = $"Income with id {id} was not found."
            });
        }

        return Ok(income);
    }
}