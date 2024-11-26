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

        public CalculateLoanController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost(Name = "CalculateLoan")]
        public ActionResult<CalculateLoanResponse> Get([FromBody] CalculateLoanRequest request)
        {
            return new CalculateLoanResponse()
            {
                ClientId = request.ClientId,
                TotalAmount = 500,
            };
        }
    }
}
