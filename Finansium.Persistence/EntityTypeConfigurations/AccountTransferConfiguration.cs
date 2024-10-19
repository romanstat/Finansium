using Finansium.Domain.Accounts;
using Finansium.Domain.Shared;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class AccountTransferConfiguration : IEntityTypeConfiguration<AccountTransfer>
{
    public void Configure(EntityTypeBuilder<AccountTransfer> builder)
    {
        builder.OwnsOne(accountTransfer => accountTransfer.Amount, amountBuilder =>
        {
            amountBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}
