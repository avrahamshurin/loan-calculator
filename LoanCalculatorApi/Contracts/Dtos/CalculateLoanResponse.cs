namespace LoanCalculatorApi.Contracts.Dtos
{
    public class CalculateLoanResponse
    {
        public int ClientId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
