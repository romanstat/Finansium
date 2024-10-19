﻿namespace Finansium.Domain.Users;

public static class EmailErrors
{
    public static readonly Error Empty = Error.Problem(
        $"{nameof(EmailErrors)}.{nameof(Empty)}", "Почта пустая");

    public static readonly Error InvalidFormat = Error.Problem(
        $"{nameof(EmailErrors)}.{nameof(InvalidFormat)}", "Недействительный формат почты");

    public static readonly Error IsUnique = Error.Problem(
        $"{nameof(EmailErrors)}.{nameof(IsUnique)}", "Почта должна быть уникальной");
}
