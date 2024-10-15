namespace Finansium.Domain.Shared;

internal sealed record FunctionCreatedDomainEvent(Ulid Id) : IDomainEvent;
