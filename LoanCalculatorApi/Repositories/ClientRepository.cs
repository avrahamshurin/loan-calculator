using System.Text.Json;
using LoanCalculatorApi.Contracts.Repositories;
using LoanCalculatorApi.Models;

namespace LoanCalculatorApi.Repositories;

public class ClientRepository : IClientRepository
{
    private const string FilePath = "Data/Clients.json";
    private readonly List<Client> _clients;

    public ClientRepository()
    {
        _clients = LoadClients();
    }
    
    public Client? GetClientById(string clientId)
    {
        return _clients.FirstOrDefault(client => client.Id == clientId);
    }
    
    private List<Client> LoadClients()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Client data file not found.");
        }

        var jsonData = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Client>>(jsonData) ?? new List<Client>();
    }

}