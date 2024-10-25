﻿namespace Finansium.Application.RecurringTransactions.Queries.GetList;

public sealed record RecurringTransactionResponse(
    Ulid Id,
    string Name,
    Money Amount,
    string Type,
    TimeSpan Interval,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    DateTimeOffset? NextPaymentDate,
    string? Description);