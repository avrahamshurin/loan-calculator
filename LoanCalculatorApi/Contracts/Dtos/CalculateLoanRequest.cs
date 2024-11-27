namespace LoanCalculatorApi.Contracts.Dtos
{
    public class CalculateLoanRequest
    {
        public int ClientId { get; set; }
        public int RequestedLoanInNis { get; set; }
        public int PeriodInMonths { get; set; }
    }
}
