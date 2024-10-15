namespace Finansium.Domain.Shared;

public sealed record RelationType(char Name)
{
    public static readonly RelationType Any = new('*');
    public static readonly RelationType A = new('A');
    public static readonly RelationType B = new('B');

    public static readonly IReadOnlyCollection<RelationType> All = [Any, A, B];

    public static RelationType? FromName(char name)
    {
        return All.FirstOrDefault(c => c.Name == name) ??
            throw new ApplicationException("Тип отношения не найден");
    }
}
