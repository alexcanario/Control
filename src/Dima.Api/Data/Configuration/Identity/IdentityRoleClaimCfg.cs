using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration.Identity;

public class IdentityRoleClaimCfg : IEntityTypeConfiguration<IdentityRoleClaim<long>>
{
	public void Configure(EntityTypeBuilder<IdentityRoleClaim<long>> b)
	{
		
		b.HasKey(rc => rc.Id);
		b.Property(rc => rc.ClaimType).HasMaxLength(255);
		b.Property(rc => rc.ClaimValue).HasMaxLength(255);
	}
}