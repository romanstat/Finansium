using System.Text.Json;
using Finansium.Domain.Accounts;
using Finansium.Domain.Budgets;
using Finansium.Domain.Categories;
using Finansium.Domain.Counties;
using Finansium.Domain.News;
using Finansium.Domain.OutboxMessages;
using Finansium.Domain.RecurringTransactions;
using Finansium.Domain.SavingsGoals;
using Finansium.Domain.Transactions;
using Finansium.Domain.Users;
using Finansium.Persistence.Extensions;

namespace Finansium.Persistence.Database;

public sealed class FinansiumDbContext(
    TimeProvider timeProvider,
    DbContextOptions<FinansiumDbContext> options)
    : DbContext(options), IFinansiumDbContext, IUnitOfWork
{
    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<AccountTransfer> AccountTransfers => Set<AccountTransfer>();

    public DbSet<Budget> Budgets => Set<Budget>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Country> Countries => Set<Country>();

    public DbSet<NewsItem> NewsItems => Set<NewsItem>();

    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

    public DbSet<RecurringTransaction> RecurringTransactions => Set<RecurringTransaction>();

    public DbSet<SavingsGoal> SavingsGoals => Set<SavingsGoal>();

    public DbSet<Transaction> Transactions => Set<Transaction>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(DependencyInjection.PersistenceAssembly);

        modelBuilder.HasDefaultSchema(Schemas.FinansiumDbContext);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Ulid>()
            .HaveConversion<UlidToStringConverter>();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            AddDomainEventsAsOutboxMessages();

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Concurrency exception occurred.", ex);
        }
    }

    private void AddDomainEventsAsOutboxMessages()
    {
        var outboxMessages = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.DomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .Select(domainEvent => OutboxMessage.Create(
                timeProvider.GetUtcNow(),
                domainEvent.GetType().Name,
                JsonSerializer.Serialize(domainEvent, JsonExtensions.DomainSerializationOptions)))
            .ToList();

        AddRange(outboxMessages);
    }
}
