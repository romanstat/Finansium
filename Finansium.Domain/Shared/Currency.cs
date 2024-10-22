namespace Finansium.Domain.Shared;

public sealed record Currency(string Code, string Name, string Sign)
{
    public static readonly Currency Usd = new("USD", "Доллар", "$");
    public static readonly Currency Eur = new("EUR", "Евро", "€");
    public static readonly Currency Byn = new("BYN", "Белорусский рубль", "Br");
    public static readonly Currency Rus = new("RUS", "Российский рубль", "₽");
    public static readonly Currency Cny = new("CNY", "Юань", "¥");

    public static readonly IReadOnlyCollection<Currency> All =
    [
        Usd,
        Eur,
        Byn,
        Rus,
        Cny
    ];

    public static Currency FromCode(string code) =>
        All.FirstOrDefault(c => c.Code == code) ??
            throw new ApplicationException("The currency code is invalid");
}
