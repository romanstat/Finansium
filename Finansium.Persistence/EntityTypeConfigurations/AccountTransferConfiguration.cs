using Finansium.Domain.Accounts;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class AccountTransferConfiguration : IEntityTypeConfiguration<AccountTransfer>
{
    public void Configure(EntityTypeBuilder<AccountTransfer> builder)
    {
        builder.OwnsOne(accountTransfer => accountTransfer.Amount, amountBuilder =>
        {
            amountBuilder.Property(money => money.Currency)
                .HasMaxLength(EntityConfigurations.CurrencyMaxLength)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .IsRequired();
        });

        builder.Property(accountTransfer => accountTransfer.Date)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();
    }
}
