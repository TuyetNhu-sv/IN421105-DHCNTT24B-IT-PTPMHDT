
namespace EduHub.Ch01.Domain;

/// <summary>
/// Represents an event organized by a club.
/// </summary>
public class Event
{
    /// <summary>Gets the unique event identifier.</summary>
    public Guid Id { get; private set; }

    /// <summary>Gets the identifier of the organizing club.</summary>
    public Guid ClubId { get; private set; }

    /// <summary>Gets the event title.</summary>
    public string Title { get; private set; } = string.Empty;

    /// <summary>Gets the event date and time.</summary>
    public DateTime Date { get; private set; }

    /// <summary>Gets the maximum number of registrations.</summary>
    public int Capacity { get; private set; }

    /// <summary>Indicates whether the event is online.</summary>
    public bool IsOnline { get; private set; }

    private Event() { }

    /// <summary>Creates an event after validating the input.</summary>
    public static Event Create(
        Guid clubId,
        string title,
        DateTime date,
        int capacity,
        bool isOnline)
    {
        if (clubId == Guid.Empty)
            throw new ArgumentException(
                "Club ID is required.", nameof(clubId));

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(
                "Event title cannot be empty.", nameof(title));

        if (date == default)
            throw new ArgumentException(
                "Event date is required.", nameof(date));

        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(capacity),
                "Capacity must be greater than zero.");

        return new Event
        {
            Id = Guid.NewGuid(),
            ClubId = clubId,
            Title = title.Trim(),
            Date = date,
            Capacity = capacity,
            IsOnline = isOnline
        };
    }

    /// <summary>
    /// Determines whether the event has remaining capacity.
    /// </summary>
    public bool HasCapacity(int registeredCount)
    {
        if (registeredCount < 0)
            throw new ArgumentOutOfRangeException(
                nameof(registeredCount));

        return registeredCount < Capacity;
    }
}
