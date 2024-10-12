namespace Finansium.Persistence.Converters;

internal sealed class UlidToStringConverter : ValueConverter<Ulid, string>
{
    public UlidToStringConverter()
        : base(
            x => x.ToString(),
            x => Ulid.Parse(x))
    {
    }
}
