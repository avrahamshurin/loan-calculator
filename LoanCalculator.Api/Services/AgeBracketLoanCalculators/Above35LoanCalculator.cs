namespace LoanCalculator.Api.Services.AgeBracketLoanCalculators;

public class Above35LoanCalculator : AgeBracketLoanCalculator
{
    protected override decimal CalculateInterest(int requestedLoanInNis)
    {
        var rate = requestedLoanInNis switch
        {
            <= 15000 => 1.5m / 100 + PrimeInterest,
            > 15000 and <= 30000 => 3m / 100 + PrimeInterest,
            > 30000 => 1m / 100
        };

        return requestedLoanInNis * rate;
    }
}