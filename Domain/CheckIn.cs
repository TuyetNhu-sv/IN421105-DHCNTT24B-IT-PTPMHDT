
namespace EduHub.Ch01.Domain;

/// <summary>
/// Defines the supported check-in methods.
/// </summary>
public enum CheckInMethod
{
    Manual,
    QrCode
}

/// <summary>
/// Records a member's attendance at an event.
/// </summary>
public class CheckIn
{
    /// <summary>Gets the check-in identifier.</summary>
    public Guid Id { get; private set; }

    /// <summary>Gets the associated registration identifier.</summary>
    public Guid RegistrationId { get; private set; }

    /// <summary>Gets the check-in date and time.</summary>
    public DateTime CheckedInAt { get; private set; }

    /// <summary>Gets the check-in method.</summary>
    public CheckInMethod Method { get; private set; }

    private CheckIn() { }

    /// <summary>Creates a check-in record.</summary>
    public static CheckIn Create(
        Guid registrationId,
        DateTime checkedInAt,
        CheckInMethod method)
    {
        if (registrationId == Guid.Empty)
            throw new ArgumentException(
                "Registration ID is required.",
                nameof(registrationId));

        if (checkedInAt == default)
            throw new ArgumentException(
                "Check-in time is required.",
                nameof(checkedInAt));

        if (!Enum.IsDefined(method))
            throw new ArgumentOutOfRangeException(
                nameof(method));

        return new CheckIn
        {
            Id = Guid.NewGuid(),
            RegistrationId = registrationId,
            CheckedInAt = checkedInAt,
            Method = method
        };
    }

    /// <summary>Returns a summary of this check-in.</summary>
    public string Summary()
    {
        return $"Check-in ID: {Id} | " +
               $"Registration ID: {RegistrationId} | " +
               $"Time: {CheckedInAt:dd/MM/yyyy HH:mm} | " +
               $"Method: {Method}";
    }
}
