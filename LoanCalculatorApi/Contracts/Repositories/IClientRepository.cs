using LoanCalculatorApi.Models;

namespace LoanCalculatorApi.Contracts.Repositories;

public interface IClientRepository
{
    Task<Client?> GetClientById(int clientId);
}