using System.Text.Json;

namespace Finansium.Persistence.Extensions;

public static class JsonExtensions
{
    public static readonly JsonSerializerOptions DomainSerializationOptions = new()
    {
        Converters = { new DomainEventConverter() },
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };
}
