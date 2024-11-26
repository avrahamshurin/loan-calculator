namespace LoanCalculatorApi.Contracts.Dtos
{
    public class CalculateLoanResponse
    {
        public string ClientId { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}
