using Finansium.Domain.SavingsGoals;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class SavingsGoalConfiguration : IEntityTypeConfiguration<SavingsGoal>
{
    public void Configure(EntityTypeBuilder<SavingsGoal> builder)
    {
        builder.OwnsOne(savingsGoal => savingsGoal.TargetAmount, targetBuilder =>
        {
            targetBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}
