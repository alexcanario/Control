using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration.Identity;

public class IdentityUserTokenCfg : IEntityTypeConfiguration<IdentityUserToken<long>>
{
	public void Configure(EntityTypeBuilder<IdentityUserToken<long>> b)
	{
		b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
		b.Property(t => t.LoginProvider).HasMaxLength(120);
		b.Property(t => t.Name).HasMaxLength(180);
	}
}