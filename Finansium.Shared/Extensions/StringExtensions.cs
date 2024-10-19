namespace Finansium.Shared.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Сравнить два значения с игнорированием регистра
    /// </summary>
    /// <param name="value"></param>
    /// <param name="compareValue"></param>
    /// <returns></returns>
    public static bool CompareIgnoreCase(this string value, string? compareValue) =>
        string.Equals(value, compareValue, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Проверить строку на пустоту
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsEmpty(this string? value) => string.IsNullOrWhiteSpace(value);
}
