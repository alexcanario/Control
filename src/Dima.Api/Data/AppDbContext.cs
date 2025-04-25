using Dima.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<Category> Categories => Set<Category>();
	public DbSet<Transaction> Transactions => Set<Transaction>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}