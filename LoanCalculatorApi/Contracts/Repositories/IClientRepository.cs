using LoanCalculatorApi.Models;

namespace LoanCalculatorApi.Contracts.Repositories;

public interface IClientRepository
{
    Client? GetClientById(string clientId);
}