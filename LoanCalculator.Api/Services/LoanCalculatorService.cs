using LoanCalculator.Api.Contracts;

namespace LoanCalculator.Api.Services;

public class LoanCalculatorService : ILoanCalculatorService
{
    private readonly ILoanCalculationStrategyFactory _strategyFactory;

    public LoanCalculatorService(ILoanCalculationStrategyFactory strategyFactory)
    {
        _strategyFactory = strategyFactory;
    }

    public Task<decimal> Calculate(int age, int requestedLoanInNis, int periodInMonths)
    {
        var strategy = _strategyFactory.CreateStrategy(age);
        return Task.FromResult(strategy.Calculate(requestedLoanInNis, periodInMonths));
    }
}