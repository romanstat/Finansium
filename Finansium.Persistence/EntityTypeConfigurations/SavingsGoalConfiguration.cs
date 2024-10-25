using Finansium.Domain.SavingsGoals;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class SavingsGoalConfiguration : IEntityTypeConfiguration<SavingsGoal>
{
    public void Configure(EntityTypeBuilder<SavingsGoal> builder)
    {
        builder.Property(savingsGoal => savingsGoal.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder.OwnsOne(savingsGoal => savingsGoal.TargetAmount, targetBuilder =>
        {
            targetBuilder.Property(money => money.Currency)
                .HasMaxLength(EntityConfigurations.CurrencyMaxLength)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                .IsRequired();
        });

        builder.Property(savingsGoal => savingsGoal.Note)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(savingsGoal => savingsGoal.StartDate)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(savingsGoal => savingsGoal.EndDate)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(savingsGoal => savingsGoal.CompletedDate).IsRequired(false);

        builder.Property(savingsGoal => savingsGoal.IsCompleted)
            .HasDefaultValue(false)
            .IsRequired();
    }
}
