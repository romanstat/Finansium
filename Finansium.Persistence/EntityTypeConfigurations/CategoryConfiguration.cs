﻿using Finansium.Domain.Categories;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasOne(category => category.Budget)
               .WithOne(budget => budget.Category)
               .HasForeignKey<Category>(category => category.BudgetId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.Property(category => category.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(category => category.TransactionType)
            .HasMaxLength(EntityConfigurations.TransactionTypeMaxLength)
            .HasConversion(transactionType => transactionType.Name, name => TransactionType.FromName(name))
            .IsRequired();
    }
}
