using FinanceDemo.Application.DTOs;
using FinanceDemo.Application.Interfaces.Repositories;
using FinanceDemo.Application.Interfaces.Services;
using FinanceDemo.Application.UseCases.Income;
using FinanceDemo.Application.UseCases.Reports;
using FinanceDemo.Domain.Entities;
using Moq;

namespace FinanceDemo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Should_Calculate_Balance_In_BOB()
        {
            decimal bobIncome = 3000;
            decimal usdIncome = 100;

            decimal exchangeRate = 6.92m;

            decimal total =
                bobIncome +
                (usdIncome * exchangeRate);

            Assert.Equal(3692m, total);
        }
        [Fact]
        public async Task Should_Calculate_Balance_In_USD()
        {
            // Arrange

            var incomeRepositoryMock =
                new Mock<IIncomeRepository>();

            var exchangeRateServiceMock =
                new Mock<IExchangeRateService>();

            var incomes = new List<Income>
        {
            new()
            {
                Amount = 6920,
                Currency = new Currency
                {
                    Code = "BOB"
                }
            },
            new()
            {
                Amount = 200,
                Currency = new Currency
                {
                    Code = "USD"
                }
            }
        };

            incomeRepositoryMock
                .Setup(x => x.GetByPeriodAsync(
                    It.IsAny<int>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(incomes);

            exchangeRateServiceMock
                .Setup(x => x.GetExchangeRateAsync())
                .ReturnsAsync(6.92m);

            var useCase =
                new GetConsolidatedBalanceUseCase(
                    incomeRepositoryMock.Object,
                    exchangeRateServiceMock.Object);

            var request =
                new ConsolidatedBalanceRequest
                {
                    UserId = 1,
                    StartDate = DateTime.Today.AddMonths(-1),
                    EndDate = DateTime.Today,
                    TargetCurrency = "USD"
                };

            // Act

            var result =
                await useCase.ExecuteAsync(request);

            // Assert

            Assert.Equal(1200m, result.TotalBalance);
        }
        [Fact]
        public async Task Should_Reject_Invalid_Currency()
        {
            var repositoryMock =
                new Mock<IIncomeRepository>();

            var useCase =
                new CreateIncomeUseCase(repositoryMock.Object);

            var request =
                new CreateIncomeRequest
                {
                    UserId = 1,
                    Amount = 100,
                    Description = "Test",
                    CurrencyId = 999,
                    IncomeSourceId = 1,
                    IncomeDate = DateTime.Today
                };

            var exception =
                await Assert.ThrowsAsync<Exception>(
                    () => useCase.ExecuteAsync(request));

            Assert.Equal(
                "Currency not supported.",
                exception.Message);
        }
    }
}
