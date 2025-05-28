using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration.Identity;

public class IdentityUserRoleCfg : IEntityTypeConfiguration<IdentityUserRole<long>>
{
	public void Configure(EntityTypeBuilder<IdentityUserRole<long>> b)
	{
		b.HasKey(ur => new { ur.RoleId, ur.UserId });
	}
}