﻿namespace Finansium.Domain.Users;

public static class UserErrors
{
    public static Error NotFound(string username) => Error.Problem(
        $"{nameof(UserErrors)}.{nameof(NotFound)}", $"Пользователь '{username}' не найден");

    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(UserErrors)}.{nameof(NotFound)}", $"Пользователь с идентификатором'{id}' не найден");

    public static readonly Error InvalidCredentials = Error.Problem(
        $"{nameof(UserErrors)}.{nameof(InvalidCredentials)}", "Неверные данные для входа");

    public static readonly Error InvalidPassword = Error.Problem(
        $"{nameof(UserErrors)}.{nameof(InvalidPassword)}", "Пароли не совпадают");

    public static Error UsernameUnique(string name) => Error.Problem(
        $"{nameof(UserErrors)}.{nameof(UsernameUnique)}", $"Имя '{name}' пользователя уже занято");
}
