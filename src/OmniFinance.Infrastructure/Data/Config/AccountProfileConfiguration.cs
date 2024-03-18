using OmniFinance.Core.AccountProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OmniFinance.Infrastructure.Data.Config;

public class AccountProfileConfiguration : IEntityTypeConfiguration<AccountProfile>
{
  public void Configure(EntityTypeBuilder<AccountProfile> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.Property(x => x.Status)
      .HasConversion(
          x => x.Value,
          x => AccountProfileStatus.FromValue(x));
  }
}
