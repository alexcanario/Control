using Dima.Api.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : 
	IdentityDbContext<UserApp, 
		IdentityRole<long>, 
		long,
		IdentityUserClaim<long>,
		IdentityUserRole<long>,
		IdentityUserLogin<long>,
		IdentityRoleClaim<long>,
		IdentityUserToken<long>>(options)
{
	public DbSet<Category> Categories => Set<Category>();
	public DbSet<Transaction> Transactions => Set<Transaction>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}