using LoanCalculator.Api.Models;

namespace LoanCalculator.Api.Contracts.Repositories;

public interface IClientRepository
{
    Task<Client?> GetClientById(int clientId);
}