using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration.Identity;

public class IdentityRoleCfg: IEntityTypeConfiguration<IdentityRole<long>>
{
	public void Configure(EntityTypeBuilder<IdentityRole<long>> b)
	{
		b.HasKey(r => r.Id);

		b.HasIndex(r => r.NormalizedName).IsUnique();

		b.Property(r => r.Name).HasMaxLength(256);
		b.Property(r => r.NormalizedName).HasMaxLength(256);
		b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
	}
}