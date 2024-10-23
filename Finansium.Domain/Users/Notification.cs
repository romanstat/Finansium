﻿namespace Finansium.Domain.Users;

public sealed class Notification : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public bool IsViewed { get; private set; }

    public static Notification Create(
        Ulid userId,
        string title,
        string description,
        DateTimeOffset createdAt)
    {
        var notification = new Notification
        {
            UserId = userId,
            Title = title,
            Description = description,
            CreatedAt = createdAt,
            IsViewed = false
        };

        return notification;
    }

    public void UserViewed()
    {
        IsViewed = true;
    }
}
