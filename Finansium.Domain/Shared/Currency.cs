﻿namespace Finansium.Domain.Shared;

public sealed record Currency(string Code)
{
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static readonly Currency By = new("BY");

    public static readonly IReadOnlyCollection<Currency> All =
    [
        Usd,
        Eur,
        By,
    ];

    public static Currency FromCode(string code) =>
        All.FirstOrDefault(c => c.Code == code) ??
            throw new ApplicationException("The currency code is invalid");
}
