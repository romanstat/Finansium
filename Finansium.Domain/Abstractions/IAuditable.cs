namespace Finansium.Domain.Abstractions;

public interface IAuditable
{
    DateTimeOffset StartDate { get; }

    DateTimeOffset ModifiedAt { get; }
}
