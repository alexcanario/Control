using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration.Identity;

public class AppUserCfg: IEntityTypeConfiguration<UserApp>
{
	public void Configure(EntityTypeBuilder<UserApp> b)
	{
		b.HasKey(u => u.Id);

		b.HasIndex(u => u.NormalizedUserName).IsUnique();
		b.HasIndex(u => u.NormalizedEmail).IsUnique();

		b.Property(u => u.Email).HasMaxLength(180);
		b.Property(u => u.NormalizedEmail).HasMaxLength(180);   
		b.Property(u => u.UserName).HasMaxLength(180);
		b.Property(u => u.NormalizedUserName).HasMaxLength(180);
		b.Property(u => u.PhoneNumber).HasMaxLength(15);
		b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

		b.HasMany<IdentityUserClaim<long>>().WithOne().HasForeignKey(u => u.UserId);
		b.HasMany<IdentityUserLogin<long>>().WithOne().HasForeignKey(u => u.UserId);
		b.HasMany<IdentityUserToken<long>>().WithOne().HasForeignKey(u => u.UserId);
		b.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(ur => ur.UserId);
	}
}