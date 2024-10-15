using Finansium.Domain.Accounts;
using Finansium.Domain.Shared;

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
    }
}
