using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration.Identity;

public class IdentityUserLoginCfg : IEntityTypeConfiguration<IdentityUserLogin<long>>
{
	public void Configure(EntityTypeBuilder<IdentityUserLogin<long>> b)
	{
		b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
		b.Property(l => l.LoginProvider).HasMaxLength(128);
		b.Property(l => l.ProviderKey).HasMaxLength(128);
		b.Property(l => l.ProviderDisplayName).HasMaxLength(256)
			.IsRequired(false);
	}
}