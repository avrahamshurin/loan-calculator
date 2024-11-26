namespace LoanCalculatorApi.Contracts.Dtos
{
    public class CalculateLoanRequest
    {
        public string ClientId { get; set; } = string.Empty; // Client ID
        public int AmountInNIS { get; set; } // Initial amount in NIS
        public int PeriodInMonths { get; set; } // Period in months
    }
}
