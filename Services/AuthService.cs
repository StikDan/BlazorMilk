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

    public async Task<bool> CheckValidClientAsync(List<client> clientData)
    {
        List<client> dbClients = LinqService.SelectClients();

        if (clientData == null || clientData.Count == 0)
            return false;

        client inputClient = clientData[0];

        for (int i = 0; i < dbClients.Count; i++)
        {
            if (dbClients[i].login == inputClient.login 
                && dbClients[i].password == inputClient.password)
            {
                return await Task.FromResult(true);
            }
        }

        return await Task.FromResult(false);
    }
}