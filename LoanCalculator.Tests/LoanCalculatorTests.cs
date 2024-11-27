using LoanCalculator.Api.Contracts;
using LoanCalculator.Api.Services;
using LoanCalculator.Api.Services.AgeBracketLoanCalculators;

namespace LoanCalculator.Tests;

public class LoanCalculatorTests
{
    private readonly ILoanCalculatorService _calculatorService;

    public LoanCalculatorTests()
    {
        var strategyFactory = new LoanCalculationStrategyFactory();
        _calculatorService = new LoanCalculatorService(strategyFactory);
    }

    [Theory]
    [InlineData(19, 4500, 13, 4664.25)]
    [InlineData(19, 10000, 12, 10350)]
    public async Task Calculate_Below20(int age, int amount, int months, decimal expectedTotal)
    {
        var result = await _calculatorService.Calculate(age, amount, months);
        Assert.Equal(expectedTotal, result);
    }

    [Theory]
    [InlineData(25, 4500, 12, 4590)]
    [InlineData(25, 10000, 12, 10300)]
    [InlineData(25, 35000, 12, 35875)]
    [InlineData(25, 10000, 13, 10315)]
    public async Task Calculate_Between20And35(int age, int amount, int months, decimal expectedTotal)
    {
        var result = await _calculatorService.Calculate(age, amount, months);
        Assert.Equal(expectedTotal, result);
    }

    [Theory]
    [InlineData(40, 14000, 12, 14420)]
    [InlineData(40, 20000, 12, 20900)]
    [InlineData(40, 35000, 12, 35350)]
    [InlineData(40, 20000, 13, 20930)]
    public async Task Calculate_Above35(int age, int amount, int months, decimal expectedTotal)
    {
        var result = await _calculatorService.Calculate(age, amount, months);
        Assert.Equal(expectedTotal, result);
    }

    [Theory]
    [InlineData(19, 10000, 11)]
    [InlineData(25, 10000, 0)]
    [InlineData(40, 10000, -1)]
    public async Task Calculate_ThrowsException_WhenPeriodBelowMinimum(int age, int amount, int months)
    {
        await Assert.ThrowsAsync<Exception>(() => _calculatorService.Calculate(age, amount, months));
    }
}
