
using EduHub.Ch01.Domain;

Console.WriteLine("====================================");
Console.WriteLine("       EDUHUB - CH01 DEMO");
Console.WriteLine("====================================");

// 1. Create a club.
Console.WriteLine("\n[1] CREATE CLUB");

var club = Club.Create(
    "Tech Club",
    "A club for technology and AI enthusiasts.");

Console.WriteLine($"Club: {club.Name}");
Console.WriteLine($"Description: {club.Description}");
Console.WriteLine($"Club ID: {club.Id}");

// 2. Create three members and add them to the club.
Console.WriteLine("\n[2] ADD MEMBERS");

var member1 = Member.Create(
    "Nguyen Van An",
    "an@example.com",
    "SV001",
    DateTime.Today);

var member2 = Member.Create(
    "Tran Thi Binh",
    "binh@example.com",
    "SV002",
    DateTime.Today);

var member3 = Member.Create(
    "Le Van Cuong",
    "cuong@example.com",
    "SV003",
    DateTime.Today);

club.AddMember(member1);
club.AddMember(member2);
club.AddMember(member3);

foreach (var member in club.Members)
{
    Console.WriteLine(
        $"- {member.Name} | {member.StudentCode} | " +
        $"Active: {member.IsActive()}");
}

Console.WriteLine($"Total members: {club.MemberCount()}");

// 3. Create an event.
Console.WriteLine("\n[3] CREATE EVENT");

var workshop = Event.Create(
    club.Id,
    "Workshop AI",
    DateTime.Today.AddDays(7),
    50,
    true);

Console.WriteLine($"Event: {workshop.Title}");
Console.WriteLine($"Date: {workshop.Date:dd/MM/yyyy}");
Console.WriteLine($"Capacity: {workshop.Capacity}");
Console.WriteLine(
    $"Online: {(workshop.IsOnline ? "Yes" : "No")}");

// 4. Register two members and confirm registrations.
Console.WriteLine("\n[4] REGISTER MEMBERS");

var registrations = new List<Registration>();

if (workshop.HasCapacity(registrations.Count))
{
    var registration1 = Registration.Create(
        member1.Id,
        workshop.Id,
        DateTime.Now);

    registrations.Add(registration1);

    Console.WriteLine(
        $"{member1.Name}: {registration1.Status}");

    registration1.Confirm();

    Console.WriteLine(
        $"{member1.Name}: {registration1.Status}");
}

if (workshop.HasCapacity(registrations.Count))
{
    var registration2 = Registration.Create(
        member2.Id,
        workshop.Id,
        DateTime.Now);

    registrations.Add(registration2);

    Console.WriteLine(
        $"{member2.Name}: {registration2.Status}");

    registration2.Confirm();

    Console.WriteLine(
        $"{member2.Name}: {registration2.Status}");
}

// 5. Create a check-in for one confirmed registration.
Console.WriteLine("\n[5] CHECK-IN");

var checkIns = new List<CheckIn>();

var confirmedRegistration = registrations.FirstOrDefault(
    registration =>
        registration.Status == RegistrationStatus.Confirmed);

if (confirmedRegistration is not null)
{
    var checkIn = CheckIn.Create(
        confirmedRegistration.Id,
        DateTime.Now,
        CheckInMethod.Manual);

    checkIns.Add(checkIn);

    Console.WriteLine(checkIn.Summary());
}

// 6. Print attendance report.
Console.WriteLine("\n[6] ATTENDANCE REPORT");
Console.WriteLine("------------------------------------");
Console.WriteLine($"Club: {club.Name}");
Console.WriteLine($"Event: {workshop.Title}");
Console.WriteLine($"Total members in club: {club.MemberCount()}");
Console.WriteLine($"Total registrations: {registrations.Count}");
Console.WriteLine($"Total check-ins: {checkIns.Count}");

Console.WriteLine("\nRegistered members:");

foreach (var registration in registrations)
{
    var member = club.Members.FirstOrDefault(
        item => item.Id == registration.MemberId);

    if (member is not null)
    {
        Console.WriteLine(
            $"- {member.Name} | {registration.Status}");
    }
}

// 7. Demonstrate business rule validation.
Console.WriteLine("\n[7] TEST BUSINESS RULE");

try
{
    var cancelledRegistration = Registration.Create(
        member3.Id,
        workshop.Id,
        DateTime.Now);

    cancelledRegistration.Cancel();

    // This operation should fail because the registration
    // has already been cancelled.
    cancelledRegistration.Confirm();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Expected error: {ex.Message}");
}

Console.WriteLine("\n====================================");
Console.WriteLine("          DEMO COMPLETED");
Console.WriteLine("====================================");
