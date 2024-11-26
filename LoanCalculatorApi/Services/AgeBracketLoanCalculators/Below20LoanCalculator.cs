namespace LoanCalculatorApi.Services.AgeBracketLoanCalculators;

public class Below20LoanCalculator : AgeBracketLoanCalculator
{
    private const decimal BasicInterest = 2m / 100; 
    protected override decimal CalculateInterest(int requestedLoanInNis)
    {
        return (BasicInterest + PrimeInterest) * requestedLoanInNis;
    }
}