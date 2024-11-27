using LoanCalculatorApi.Contracts;
using LoanCalculatorApi.Services.AgeBracketLoanCalculators;

namespace LoanCalculatorApi.Services;

public class LoanCalculator : ILoanCalculator
{
    public Task<decimal> Calculate(int age, int requestedLoanInNis, int periodInMonths)
    {
        AgeBracketLoanCalculator loanCalculator = age switch
        {
            <= 20 => new Below20LoanCalculator(),
            > 20 and <= 35 => new Between20And35LoanCalculator(),
            > 35 => new Above35LoanCalculator()
        };

        return Task.FromResult(loanCalculator.Calculate(requestedLoanInNis, periodInMonths));
    }
}