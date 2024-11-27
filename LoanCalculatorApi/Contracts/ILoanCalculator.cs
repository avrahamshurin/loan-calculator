namespace LoanCalculatorApi.Contracts;

public interface ILoanCalculator
{
    Task<decimal> Calculate(int age, int requestedLoanInNis, int periodInMonths);
}