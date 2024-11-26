using Finansium.Domain.Accounts;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(account => account.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder.ComplexProperty(account => account.Balance, balanceBuilder =>
        {
            balanceBuilder.Property(money => money.Currency)
                .HasMaxLength(EntityConfigurations.CurrencyMaxLength)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .IsRequired();
        });

        builder.Property(account => account.CreatedAt)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(account => account.ModifiedAt)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();
    }
}
