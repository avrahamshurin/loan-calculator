using LoanCalculator.Api.Contracts;

namespace LoanCalculator.Api.Services.AgeBracketLoanCalculators;

public class LoanCalculationStrategyFactory : ILoanCalculationStrategyFactory
{
    public ILoanCalculationStrategy CreateStrategy(int age)
    {
        return age switch
        {
            <= 20 => new Below20LoanCalculator(),
            > 20 and <= 35 => new Between20And35LoanCalculator(),
            _ => new Above35LoanCalculator()
        };
    }
}
