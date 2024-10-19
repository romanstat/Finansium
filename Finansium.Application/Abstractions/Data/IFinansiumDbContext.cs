namespace Finansium.Application.Abstractions.Data;

public interface IFinansiumDbContext
{
    DbSet<User> Users { get; }
}
