using Finansium.Domain.Accounts;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.OwnsOne(account => account.Balance, balanceBuilder =>
        {
            balanceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.Property(account => account.Status)
            .HasConversion(status => status.Name, name => AccountStatus.FromName(name));
    }
}
