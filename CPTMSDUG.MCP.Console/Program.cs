using CPTMSDUG.MCP.Core.Services;

Console.WriteLine("CPTMSDUG MCP Data Store Test");
Console.WriteLine("============================");

// Create HttpClient and data store
using var httpClient = new HttpClient();
var dataStore = new CptmsdugDataStore(httpClient);

Console.WriteLine("Loading CPTMSDUG data...");

try
{
    // Test loading the complete data
    var data = await dataStore.GetDataAsync();
    Console.WriteLine($"✓ Data loaded successfully");
    Console.WriteLine($"  Organization: {data.Organization.Name}");
    Console.WriteLine($"  Version: {data.Version}");
    Console.WriteLine($"  Location: {data.Organization.Location.City}, {data.Organization.Location.Country}");

    // Test accessing community stats
    var stats = await dataStore.GetCommunityStatsAsync();
    Console.WriteLine($"\nCommunity Stats:");
    Console.WriteLine($"  Members: {stats.Members}");
    Console.WriteLine($"  Events Hosted: {stats.EventsHosted}");
    Console.WriteLine($"  Rating: {stats.Rating}");

    // Test accessing upcoming events
    var events = await dataStore.GetUpcomingEventsAsync();
    Console.WriteLine($"\nUpcoming Events: {events.Count}");
    foreach (var evt in events.Take(3))
    {
        Console.WriteLine($"  - {evt.Name} ({evt.Date})");
    }

    // Test accessing speakers
    var speakers = await dataStore.GetSpeakersAsync();
    Console.WriteLine($"\nSpeakers: {speakers.Count}");
    foreach (var speaker in speakers.Take(3))
    {
        Console.WriteLine($"  - {speaker.Name} ({speaker.Company})");
    }

    // Test accessing technologies
    var technologies = await dataStore.GetTechnologiesAsync();
    Console.WriteLine($"\nPrimary Technologies: {technologies.Primary.Count}");
    foreach (var tech in technologies.Primary.Take(3))
    {
        Console.WriteLine($"  - {tech}");
    }

    Console.WriteLine($"\n✓ All tests completed successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"✗ Error: {ex.Message}");
    Console.WriteLine($"Stack trace: {ex.StackTrace}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
