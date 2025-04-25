using Dima.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Configuration;

public class TransactionCfg : IEntityTypeConfiguration<Transaction>
{
	public void Configure(EntityTypeBuilder<Transaction> builder)
	{
		builder.ToTable("Categories");
		builder.HasKey(t => t.Id);

		builder.Property(t => t.Title).IsRequired(true).HasColumnType("nvarchar").HasMaxLength(80);
		builder.Property(t => t.Type).IsRequired(true).HasColumnType("smallint");
		builder.Property(t => t.Amount).IsRequired(true).HasColumnType("money");
		builder.Property(t => t.CreatedAt).IsRequired(true);
		builder.Property(t => t.PaidOrReceivedAt).IsRequired(false);
		builder.Property(t => t.UserId).IsRequired(true).HasColumnType("varchar").HasMaxLength(160);
	}
}