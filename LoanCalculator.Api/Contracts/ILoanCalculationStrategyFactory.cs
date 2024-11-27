namespace LoanCalculator.Api.Contracts;

public interface ILoanCalculationStrategyFactory
{
    ILoanCalculationStrategy CreateStrategy(int age);
}