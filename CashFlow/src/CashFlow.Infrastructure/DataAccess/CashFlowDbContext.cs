using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("CASHFLOW_DB");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new Exception("The CASHFLOW_DB environment variable was not found.");

        var version = new Version(8, 0, 44);
        var serverVersion = new MySqlServerVersion(version);

        optionsBuilder.UseMySql(connectionString, serverVersion);

    }
}
 