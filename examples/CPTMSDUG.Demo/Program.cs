using CPTMSDUG.Data.Services;

Console.WriteLine("CPTMSDUG Data Library Demo");
Console.WriteLine("==========================");

// Initialize the data service
var dataService = new CptmsdugDataService();

// Get the path to the data file
var currentDirectory = Directory.GetCurrentDirectory();
var repositoryRoot = Path.GetFullPath(Path.Combine(currentDirectory, "..", ".."));
var dataPath = Path.Combine(repositoryRoot, "data", "cptmsdug_data.json");

try
{
    // Load the data
    Console.WriteLine($"Loading data from: {dataPath}");
    var data = await dataService.LoadDataAsync(dataPath);
    
    if (data == null)
    {
        Console.WriteLine("Failed to load data.");
        return;
    }

    Console.WriteLine("Data loaded successfully!\n");

    // Display user group information
    var userGroup = dataService.GetUserGroup();
    Console.WriteLine($"User Group: {userGroup?.Name}");
    Console.WriteLine($"Acronym: {userGroup?.Acronym}");
    Console.WriteLine($"Website: {userGroup?.Website}");
    Console.WriteLine($"Member Count: {userGroup?.MemberCount}");
    Console.WriteLine($"Twitter: {userGroup?.SocialLinks?.Twitter}");
    Console.WriteLine();

    // Display events
    var events = dataService.GetEvents();
    Console.WriteLine($"Upcoming Events ({events.Count}):");
    foreach (var evt in events.Take(3)) // Show first 3 events
    {
        Console.WriteLine($"  - {evt.Title}");
        Console.WriteLine($"    Date: {evt.Date.Formatted}");
        Console.WriteLine($"    Venue: {evt.Venue}");
        if (evt.Attendees.HasValue)
        {
            Console.WriteLine($"    Attendees: {evt.Attendees}");
        }
        Console.WriteLine();
    }

    // Display speakers
    var speakers = dataService.GetSpeakers();
    Console.WriteLine($"Speakers ({speakers.Count}):");
    foreach (var speaker in speakers.Take(5)) // Show first 5 speakers
    {
        Console.WriteLine($"  - {speaker.Name}");
        Console.WriteLine($"    Bio: {speaker.Bio}");
        Console.WriteLine();
    }

    // Display summary
    var summary = dataService.GetSummary();
    Console.WriteLine("Summary:");
    Console.WriteLine($"  Total Events: {summary?.TotalEvents}");
    Console.WriteLine($"  Total Speakers: {summary?.TotalSpeakers}");
    Console.WriteLine($"  Total Conferences: {summary?.TotalConferences}");
    Console.WriteLine($"  Upcoming Events: {summary?.UpcomingEvents}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
