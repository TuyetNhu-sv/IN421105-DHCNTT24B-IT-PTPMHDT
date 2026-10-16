
namespace EduHub.Ch01.Domain;

/// <summary>
/// Represents a student who participates in EduHub clubs.
/// </summary>
public class Member
{
    /// <summary>Gets the unique member identifier.</summary>
    public Guid Id { get; private set; }

    /// <summary>Gets the member's full name.</summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>Gets the member's email address.</summary>
    public string Email { get; private set; } = string.Empty;

    /// <summary>Gets the student code.</summary>
    public string StudentCode { get; private set; } = string.Empty;

    /// <summary>Gets the date the member joined.</summary>
    public DateTime JoinedAt { get; private set; }

    private Member() { }

    /// <summary>Creates a member after validating the input.</summary>
    public static Member Create(
        string name,
        string email,
        string studentCode,
        DateTime joinedAt)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Name cannot be empty.", nameof(name));

        if (string.IsNullOrWhiteSpace(email) ||
            !email.Contains('@'))
            throw new ArgumentException(
                "Invalid email address.", nameof(email));

        if (string.IsNullOrWhiteSpace(studentCode))
            throw new ArgumentException(
                "Student code cannot be empty.",
                nameof(studentCode));

        if (joinedAt == default)
            throw new ArgumentException(
                "Join date is required.", nameof(joinedAt));

        return new Member
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            Email = email.Trim(),
            StudentCode = studentCode.Trim(),
            JoinedAt = joinedAt
        };
    }

    /// <summary>Indicates whether the member is active.</summary>
    public bool IsActive()
    {
        return !string.IsNullOrWhiteSpace(StudentCode);
    }
}
