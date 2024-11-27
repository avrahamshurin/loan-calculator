using LoanCalculator.Api.Contracts;
using LoanCalculator.Api.Contracts.Dtos;
using LoanCalculator.Api.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateLoanController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILoanCalculatorService _loanCalculatorService;

        public CalculateLoanController(
            IClientRepository clientRepository, 
            ILoanCalculatorService loanCalculatorService)
        {
            _clientRepository = clientRepository;
            _loanCalculatorService = loanCalculatorService;
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
                var totalAmount = await _loanCalculatorService.Calculate(client.Age, request.RequestedLoanInNis, request.PeriodInMonths);
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
