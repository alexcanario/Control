using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration.Identity;

public class IdentityUserClaimCfg : IEntityTypeConfiguration<IdentityUserClaim<long>>
{
	public void Configure(EntityTypeBuilder<IdentityUserClaim<long>> b)
	{
		b.HasKey(c => c.Id);
		b.Property(c => c.UserId).IsRequired();

		b.Property(c => c.ClaimType).HasMaxLength(255);
		b.Property(c => c.ClaimValue).HasMaxLength(255);
	}
}