﻿namespace Finansium.Application.RecurringTransactions.Queries.Search;

public sealed record RecurringTransactionResponse(
    Ulid Id,
    string AccountName,
    decimal Amount,
    string Type,
    TimeSpan Interval,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    DateTimeOffset? NextPaymentDate,
    string? Description);
