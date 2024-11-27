namespace LoanCalculatorApi.Contracts;

public interface ILoanCalculationStrategyFactory
{
    ILoanCalculationStrategy CreateStrategy(int age);
}