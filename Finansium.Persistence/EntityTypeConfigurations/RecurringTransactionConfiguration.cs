using Finansium.Domain.RecurringTransactions;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class RecurringTransactionConfiguration : IEntityTypeConfiguration<RecurringTransaction>
{
    public void Configure(EntityTypeBuilder<RecurringTransaction> builder)
    {
        builder.OwnsOne(recurringTransaction => recurringTransaction.Amount, amountBuilder =>
        {
            amountBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.Property(recurringTransaction => recurringTransaction.Type)
            .HasConversion(transactionType => transactionType.Name, name => TransactionType.FromName(name));
    }
}
