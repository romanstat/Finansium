namespace Finansium.Application.Countries.Queries;

public sealed record CountryResponse(
    Ulid Id,
    string ShortName,
    string FullName,
    string Alpha2Code,
    string Alpha3Code,
    short NumericCode);
