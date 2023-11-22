﻿using MaterialDeContrucaoAppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MaterialDeContrucaoAppWeb.Data;

public class MatConstDBContext : DbContext 
{
    public DbSet<Produto> Produtos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string myConn = config.GetConnectionString("MyConn");

        optionsBuilder.UseSqlServer(myConn);
    }
}

