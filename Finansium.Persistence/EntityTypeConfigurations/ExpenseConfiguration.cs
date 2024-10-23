using Finansium.Domain.Expenses;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.OwnsOne(expense => expense.Amount, balanceBuilder =>
        {
            balanceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}
