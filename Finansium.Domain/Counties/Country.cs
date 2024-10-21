namespace Finansium.Domain.Counties;

public sealed class Country : Entity
{
    public string ShortName { get; private set; }

    public string FullName { get; private set; }

    public string Alpha2Code { get; private set; }

    public string Alpha3Code { get; private set; }

    public short NumericCode { get; private set; }

    public static Country Create(
        string shortName,
        string fullName,
        string alpha2Code,
        string alpha3Code,
        short numericCode)
    {
        var country = new Country
        {
            ShortName = shortName,
            FullName = fullName,
            Alpha2Code = alpha2Code,
            Alpha3Code = alpha3Code,
            NumericCode = numericCode
        };

        return country;
    }
}
