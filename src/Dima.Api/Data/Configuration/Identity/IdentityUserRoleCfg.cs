using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration.Identity;

public class IdentityUserRoleCfg : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
	public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> b)
	{
		b.HasKey(ur => new { ur.RoleId, ur.UserId });
	}
}