namespace Finansium.Domain.TODO;

internal sealed record FunctionCreatedDomainEvent(Ulid Id) : IDomainEvent;
