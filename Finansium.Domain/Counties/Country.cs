namespace Finansium.Domain.Counties;

public sealed class Country : Entity
{
    public string ShortName { get; init; }

    public string FullName { get; init; }

    public string Alpha2Code { get; init; }

    public string Alpha3Code { get; init; }

    public int NumericCode { get; init; }
}
