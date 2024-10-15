﻿using Finansium.Domain.Accounts;
using Finansium.Domain.Shared;

namespace Finansium.Domain.Incomes;

/// <summary>
/// Доходы
/// </summary>
public sealed class Income : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public Ulid AcoountId { get; private set; }

    public Account? Account { get; private set; }

    public Money Amount { get; private set; }

    public DateTimeOffset Date { get; private set; }
}
