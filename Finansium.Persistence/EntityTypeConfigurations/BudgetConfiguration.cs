using Finansium.Domain.Budgets;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.Property(budget => budget.Type)
            .HasConversion(type => type.Name, name => BudgetType.FromName(name));
    }
}
