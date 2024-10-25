using Finansium.Domain.Transactions;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(transaction => transaction.Type)
            .HasMaxLength(EntityConfigurations.TransactionTypeMaxLength)
            .HasConversion(transactionType => transactionType.Name, name => TransactionType.FromName(name))
            .IsRequired();

        builder.OwnsOne(transaction => transaction.Amount, amountBuilder =>
        {
            amountBuilder.Property(money => money.Currency)
                .HasMaxLength(EntityConfigurations.CurrencyMaxLength)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .IsRequired();
        });

        builder.Property(transaction => transaction.Date)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(transaction => transaction.Description)
            .HasMaxLength(500)
            .IsRequired();
    }
}
