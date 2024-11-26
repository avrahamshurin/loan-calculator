namespace LoanCalculatorApi.Contracts;

public interface ILoanCalculator
{
    decimal Calculate(int age, int requestedLoanInNis, int periodInMonths);
}