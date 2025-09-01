using CPTMSDUG.Data.Services;

Console.WriteLine("CPTMSDUG Data Library Demo");
Console.WriteLine("==========================");

// Use the GitHub URL for the data
var dataUrl = "https://raw.githubusercontent.com/mattleibow/CPTMSDUG-MCP-Server/refs/heads/main/data/cptmsdug.json";

try
{
    // Initialize the data service - this starts loading data in the background
    Console.WriteLine($"Initializing service with data from: {dataUrl}");
    var dataService = new CptmsdugDataService(dataUrl);
    Console.WriteLine("Service initialized - data loading in background...\n");

    // Display user group information
    var userGroup = await dataService.GetUserGroupAsync();
    Console.WriteLine($"User Group: {userGroup?.Name}");
    Console.WriteLine($"Acronym: {userGroup?.Acronym}");
    Console.WriteLine($"Website: {userGroup?.Website}");
    Console.WriteLine($"Member Count: {userGroup?.MemberCount}");
    Console.WriteLine($"Twitter: {userGroup?.SocialLinks?.Twitter}");
    Console.WriteLine();

    // Display events
    var events = await dataService.GetEventsAsync();
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
    var speakers = await dataService.GetSpeakersAsync();
    Console.WriteLine($"Speakers ({speakers.Count}):");
    foreach (var speaker in speakers.Take(5)) // Show first 5 speakers
    {
        Console.WriteLine($"  - {speaker.Name}");
        Console.WriteLine($"    Bio: {speaker.Bio}");
        Console.WriteLine();
    }

    // Display summary
    var summary = await dataService.GetSummaryAsync();
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
