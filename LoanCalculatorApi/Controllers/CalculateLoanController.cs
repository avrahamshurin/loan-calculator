using LoanCalculatorApi.Contracts;
using LoanCalculatorApi.Contracts.Dtos;
using LoanCalculatorApi.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateLoanController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILoanCalculator _loanCalculator;

        public CalculateLoanController(
            IClientRepository clientRepository, 
            ILoanCalculator loanCalculator)
        {
            _clientRepository = clientRepository;
            _loanCalculator = loanCalculator;
        }

        [HttpPost(Name = "CalculateLoan")]
        public ActionResult<CalculateLoanResponse> Get([FromBody] CalculateLoanRequest request)
        {
            var clientId = request.ClientId;
            
            var client = _clientRepository.GetClientById(clientId);
            if (client == null)
            {
                return NotFound($"Client with id {clientId} not found");
            }

            var totalAmount = _loanCalculator.Calculate(client.Age, request.AmountInNIS, request.PeriodInMonths);
            return new CalculateLoanResponse()
            {
                ClientId = request.ClientId,
                TotalAmount = totalAmount,
            };
        }
    }
}
