using Finansium.Domain.Incomes;
using Finansium.Domain.Shared;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.OwnsOne(income => income.Amount, amountBuilder =>
        {
            amountBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}
