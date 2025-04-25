using Dima.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration;

public class CategoryCfg : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Title).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
		builder.Property(c => c.Description).IsRequired().HasColumnType("nvarchar").HasMaxLength(80);
		builder.Property(c => c.UserId);
	}
}