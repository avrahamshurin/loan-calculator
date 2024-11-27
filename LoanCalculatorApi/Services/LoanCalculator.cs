using LoanCalculatorApi.Contracts;
namespace LoanCalculatorApi.Services;

public class LoanCalculator : ILoanCalculator
{
    private readonly ILoanCalculationStrategyFactory _strategyFactory;

    public LoanCalculator(ILoanCalculationStrategyFactory strategyFactory)
    {
        _strategyFactory = strategyFactory;
    }

    public Task<decimal> Calculate(int age, int requestedLoanInNis, int periodInMonths)
    {
        var strategy = _strategyFactory.CreateStrategy(age);
        return Task.FromResult(strategy.Calculate(requestedLoanInNis, periodInMonths));
    }
}