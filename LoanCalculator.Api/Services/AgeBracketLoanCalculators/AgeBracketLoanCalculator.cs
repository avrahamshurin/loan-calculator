using LoanCalculator.Api.Contracts;

namespace LoanCalculator.Api.Services.AgeBracketLoanCalculators;

public abstract class AgeBracketLoanCalculator : ILoanCalculationStrategy
{
    private const int MinLoanPeriodInMonths = 12;
    protected const decimal PrimeInterest = 1.5m / 100;
    private const decimal ExtraMonthInterest = 0.15m / 100;
    
    public decimal Calculate(int requestedLoanInNis, int periodInMonths)
    {
        if (periodInMonths < MinLoanPeriodInMonths)
        {
            throw new Exception($"Min period is {MinLoanPeriodInMonths} months");
        }

        var interest = CalculateInterest(requestedLoanInNis);
        interest += (periodInMonths - MinLoanPeriodInMonths) * ExtraMonthInterest * requestedLoanInNis;

        return requestedLoanInNis + interest;
    }

    protected abstract decimal CalculateInterest(int requestedLoanInNis);
}