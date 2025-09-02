# CPTMSDUG MCP Server

A C# library for loading and working with Cape Town MS Developer User Group data from https://cptmsdug.dev/mcp.json.

## Features

- **Fast Startup**: Data loading begins immediately in constructor for quick initialization
- **Background Loading**: HTTP requests are cached and awaited only when data is accessed
- **Strongly Typed Models**: Complete C# classes mapping to the JSON structure
- **Async APIs**: All data access methods are async for optimal performance

## Usage

### Basic Setup

```csharp
using CPTMSDUG.MCP.Core.Services;

// Create HttpClient and data store
using var httpClient = new HttpClient();
var dataStore = new CptmsdugDataStore(httpClient);

// Get complete data
var data = await dataStore.GetDataAsync();
Console.WriteLine($"Organization: {data.Organization.Name}");
```

### Accessing Specific Data

```csharp
// Get community statistics
var stats = await dataStore.GetCommunityStatsAsync();
Console.WriteLine($"Members: {stats.Members}");

// Get upcoming events
var events = await dataStore.GetUpcomingEventsAsync();
foreach (var evt in events)
{
    Console.WriteLine($"{evt.Name} - {evt.Date}");
}

// Get speakers
var speakers = await dataStore.GetSpeakersAsync();
foreach (var speaker in speakers)
{
    Console.WriteLine($"{speaker.Name} ({speaker.Company})");
}

// Get technologies
var technologies = await dataStore.GetTechnologiesAsync();
foreach (var tech in technologies.Primary)
{
    Console.WriteLine($"Primary Tech: {tech}");
}
```

### Dependency Injection

For ASP.NET Core or other DI frameworks:

```csharp
services.AddHttpClient<ICptmsdugDataStore, CptmsdugDataStore>();
```

## Data Structure

The library provides models for:

- **Organization Info**: Name, location, affiliations
- **Community Stats**: Member count, events hosted, ratings
- **Events**: Upcoming events with agendas, speakers, topics
- **Speakers**: Speaker profiles and session information
- **Technologies**: Primary and secondary technology focus areas
- **Contact Info**: Email addresses and social media links
- **Opportunities**: Speaking, sponsorship, and volunteering options

## Performance Characteristics

- **Constructor**: Starts HTTP request immediately (non-blocking)
- **First API Call**: Awaits cached Task, returns data quickly
- **Subsequent Calls**: Return immediately from cached data
- **Error Handling**: Returns empty objects on failure, logs errors

## Projects

- **CPTMSDUG.MCP.Core**: Main library with models and services
- **CPTMSDUG.MCP.Console**: Example console application

## Dependencies

- .NET 8.0
- System.Text.Json (built-in)
- HttpClient (built-in)

## Testing

Run the console application to test:

```bash
cd CPTMSDUG.MCP.Console
dotnet run
```

This will load data from the live API and display key information to verify everything is working correctly.
