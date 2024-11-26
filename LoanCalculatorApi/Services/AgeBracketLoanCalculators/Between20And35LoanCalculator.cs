namespace LoanCalculatorApi.Services.AgeBracketLoanCalculators;

public class Between20And35LoanCalculator : AgeBracketLoanCalculator
{
    protected override decimal CalculateInterest(int requestedLoanInNis)
    {
        var rate = requestedLoanInNis switch
        {
            <= 5000 => 2m / 100,
            > 5000 and <= 30000 => 1.5m / 100 + PrimeInterest,
            > 30000 => 1m / 100 + PrimeInterest
        };

        return requestedLoanInNis * rate;
    }
}