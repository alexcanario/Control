using Control.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Control.Api.Data;

public class AppDbContextContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;
}