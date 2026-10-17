
namespace EduHub.Ch01.Domain;

/// <summary>
/// Represents a student club in EduHub.
/// </summary>
public class Club
{
    private readonly List<Member> _members = new();

    /// <summary>Gets the unique club identifier.</summary>
    public Guid Id { get; private set; }

    /// <summary>Gets the club name.</summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>Gets the club description.</summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>Gets the club creation date.</summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>Gets the members of the club.</summary>
    public IReadOnlyList<Member> Members => _members.AsReadOnly();

    private Club() { }

    /// <summary>Creates a club after validating the input.</summary>
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Club name cannot be empty.", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException(
                "Description cannot be empty.",
                nameof(description));

        return new Club
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            Description = description.Trim(),
            CreatedAt = DateTime.Now
        };
    }

    /// <summary>Adds a member to the club.</summary>
    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);

        if (_members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException(
                "Member already belongs to this club.");

        _members.Add(member);
    }

    /// <summary>Returns the number of club members.</summary>
    public int MemberCount()
    {
        return _members.Count;
    }
}
