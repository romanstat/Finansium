using System.Text.Json;
using System.Text.Json.Serialization;

namespace Finansium.Persistence.Converters;

public class DomainEventConverter : JsonConverter<IDomainEvent>
{
    public override IDomainEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);

        var jsonObject = jsonDoc.RootElement;

        if (jsonObject.TryGetProperty("$type", out var typeProperty))
        {
            var typeName = typeProperty.GetString()!;

            var eventType = Type.GetType(typeName) ?? throw new JsonException($"Не удалось найти тип: {typeName}");

            return (IDomainEvent)JsonSerializer.Deserialize(jsonObject.GetRawText(), eventType, options);
        }

        throw new JsonException("Поле $type не найдено в JSON.");
    }

    public override void Write(Utf8JsonWriter writer, IDomainEvent value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("$type", value.GetType().AssemblyQualifiedName);

        foreach (var property in value.GetType().GetProperties())
        {
            var propertyValue = property.GetValue(value);

            writer.WritePropertyName(property.Name);

            JsonSerializer.Serialize(writer, propertyValue, propertyValue?.GetType() ?? typeof(object), options);
        }

        writer.WriteEndObject();
    }
}
