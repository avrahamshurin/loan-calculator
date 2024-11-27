namespace LoanCalculator.Api.Contracts;

public interface ILoanCalculatorService
{
    Task<decimal> Calculate(int age, int requestedLoanInNis, int periodInMonths);
}