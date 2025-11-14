using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BlazorMilk.Models;
using BlazorMilk.Data;

namespace BlazorMilk.Services;

public class LinqService
{
    private readonly AppDbContext _db;

    public LinqService(AppDbContext db)
    {
        _db = db;
    }

    public List<client> SelectClients()
    {
        return _db.client.ToList();
    }
}