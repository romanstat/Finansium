using Finansium.Domain.SavingsGoals;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class SavingsGoalConfiguration : IEntityTypeConfiguration<SavingsGoal>
{
    public void Configure(EntityTypeBuilder<SavingsGoal> builder)
    {
        builder.OwnsOne(savingsGoal => savingsGoal.Current, currentBuilder =>
        {
            currentBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(savingsGoal => savingsGoal.Target, targetBuilder =>
        {
            targetBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}
