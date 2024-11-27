namespace LoanCalculator.Api.Contracts;

public interface ILoanCalculationStrategy
{    
    decimal Calculate(int requestedLoanInNis, int periodInMonths);
}