using Finansium.Domain.RecurringTransactions;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class RecurringTransactionConfiguration : IEntityTypeConfiguration<RecurringTransaction>
{
    public void Configure(EntityTypeBuilder<RecurringTransaction> builder)
    {
        builder.Property(recurringTransaction => recurringTransaction.Type);

        builder.Property(recurringTransaction => recurringTransaction.Type)
            .HasMaxLength(EntityConfigurations.TransactionTypeMaxLength)
            .HasConversion(transactionType => transactionType.Name, name => TransactionType.FromName(name))
            .IsRequired();

        builder.OwnsOne(recurringTransaction => recurringTransaction.Amount, amountBuilder =>
        {
            amountBuilder.Property(money => money.Currency)
                .HasMaxLength(EntityConfigurations.CurrencyMaxLength)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .IsRequired();
        });

        builder.Property(recurringTransaction => recurringTransaction.StartDate)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(recurringTransaction => recurringTransaction.EndDate)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(recurringTransaction => recurringTransaction.CreatedAt)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(recurringTransaction => recurringTransaction.Description)
            .HasMaxLength(500)
            .IsRequired(false);
    }
}
