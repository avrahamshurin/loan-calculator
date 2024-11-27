using System.Text.Json;
using LoanCalculator.Api.Contracts.Repositories;
using LoanCalculator.Api.Models;

namespace LoanCalculator.Api.Repositories;

public class ClientRepository : IClientRepository
{
    private const string FilePath = "Data/Clients.json";

    public async Task<Client?> GetClientById(int clientId)
    {
        var clients = await LoadClients();
        return clients.FirstOrDefault(client => client.Id == clientId);
    }
    
    private async Task<List<Client>> LoadClients()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Client data file not found.");
        }

        var jsonData = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<Client>>(jsonData) ?? new List<Client>();
    }

}