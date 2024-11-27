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
        public async Task<ActionResult<CalculateLoanResponse>> CalculateLoan([FromBody] CalculateLoanRequest request)
        {
            var clientId = request.ClientId;
            
            var client = await _clientRepository.GetClientById(clientId);
            if (client == null)
            {
                return NotFound(new {message = $"Client with id {clientId} not found"});
            }

            try
            {
                var totalAmount = await _loanCalculator.Calculate(client.Age, request.RequestedLoanInNis, request.PeriodInMonths);
                return Ok(new CalculateLoanResponse()
                {
                    ClientId = clientId,
                    TotalAmount = totalAmount,
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "An error occurred while processing the loan calculation.", details = e.Message });
            }
        }
    }
}
