using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using BlazorMilk.Data;
using BlazorMilk.Models;

namespace BlazorMilk.Services;

public class AuthService
{
    private readonly ProtectedSessionStorage _protectedSessionStorage;
    private readonly AppDbContext _db;

    LinqService LinqService { get; }
    HashService HashService { get; set; } = new HashService();

    public AuthService(AppDbContext db, ProtectedSessionStorage protectedSessionStorage)
    {
        _protectedSessionStorage = protectedSessionStorage;
        _db = db;

        LinqService = new LinqService(_db);
    }

    public bool HandleClientData(client client)
    {
        Random rnd = new();
        int randonId = rnd.Next(1, 10000);

        string hashPassword = HashService.CalculateHashData(client.password);

        client.idClient = randonId;
        client.login = client.login;
        client.password = hashPassword;

        List<client> clientData = new() {client};

        bool result = CheckValidClient(clientData);
        return result;
    }

    public bool CheckValidClient(List<client> clientData)
    {
        List<client> dbClients = LinqService.SelectClients();
        for(int i = 0; i <= dbClients.Count; i++)
        {
            if(dbClients[i] == clientData[i])
            {
                return true;
            }
        }
        return false;
    }
}