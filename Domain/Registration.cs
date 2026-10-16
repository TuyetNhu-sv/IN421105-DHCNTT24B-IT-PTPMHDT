
namespace EduHub.Ch01.Domain;

/// <summary>
/// Defines the possible registration states.
/// </summary>
public enum RegistrationStatus
{
    Pending,
    Confirmed,
    Cancelled
}

/// <summary>
/// Represents a member's registration for an event.
/// </summary>
public class Registration
{
    /// <summary>Gets the registration identifier.</summary>
    public Guid Id { get; private set; }

    /// <summary>Gets the registered member identifier.</summary>
    public Guid MemberId { get; private set; }

    /// <summary>Gets the event identifier.</summary>
    public Guid EventId { get; private set; }

    /// <summary>Gets the registration date.</summary>
    public DateTime RegisteredAt { get; private set; }

    /// <summary>Gets the registration status.</summary>
    public RegistrationStatus Status { get; private set; }

    private Registration() { }

    /// <summary>Creates a pending registration.</summary>
    public static Registration Create(
        Guid memberId,
        Guid eventId,
        DateTime registeredAt)
    {
        if (memberId == Guid.Empty)
            throw new ArgumentException(
                "Member ID is required.", nameof(memberId));

        if (eventId == Guid.Empty)
            throw new ArgumentException(
                "Event ID is required.", nameof(eventId));

        if (registeredAt == default)
            throw new ArgumentException(
                "Registration date is required.",
                nameof(registeredAt));

        return new Registration
        {
            Id = Guid.NewGuid(),
            MemberId = memberId,
            EventId = eventId,
            RegisteredAt = registeredAt,
            Status = RegistrationStatus.Pending
        };
    }

    /// <summary>Confirms a pending registration.</summary>
    public void Confirm()
    {
        if (Status != RegistrationStatus.Pending)
            throw new InvalidOperationException(
                "Only pending registrations can be confirmed.");

        Status = RegistrationStatus.Confirmed;
    }

    /// <summary>Cancels a pending or confirmed registration.</summary>
    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException(
                "Registration is already cancelled.");

        Status = RegistrationStatus.Cancelled;
    }
}
