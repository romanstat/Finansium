using System.Reflection;

namespace Finansium.Shared.Extensions;

public static class ReflectionExtensions
{
    /// <summary>
    /// Получить список названий всех публичных свойств типа
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IReadOnlyList<string> GetPropertyNames<T>()
        where T : class => GetPropertiesInfo<T>()
            .Select(p => p.Name)
            .ToList();

    /// <summary>
    /// Получить информацию о всех публичных свойствах типа
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IReadOnlyList<PropertyInfo> GetPropertiesInfo<T>()
        where T : class
    {
        var properties = typeof(T)
            .GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.Static)
            .ToList();

        return properties;
    }

    /// <summary>
    /// Получить информацию о всех публичных свойствах типа
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IReadOnlyList<PropertyInfo> GetPropertiesInfo(this Type type)
    {
        var properties = type
            .GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.Static)
            .ToList();

        return properties;
    }
}
