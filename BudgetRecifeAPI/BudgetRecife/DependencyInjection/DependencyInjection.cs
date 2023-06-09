﻿using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

public static class DependencyInjectionExtensions
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration config)
    {
        string connectionString = config["ConnectionStrings:DefaultConnection"];

        // Configure EF Core with Oracle
        services.AddDbContext<MyDbContext>(options =>
            options.UseOracle(connectionString));

        // Add repository classes
        services.AddScoped<IBudgetRepository, BudgetRepository>();

        // Add services
        services.AddScoped<IBudgetService, BudgetService>();

    }
}