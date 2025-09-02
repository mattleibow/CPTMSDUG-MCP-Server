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
- **CPTMSDUG.MCP.Tests**: XUnit test project with comprehensive tests

## Dependencies

- .NET 8.0
- System.Text.Json (built-in)
- HttpClient (built-in)
- NJsonSchema (for schema validation in tests)

## Testing

Run the test suite to verify functionality:

```bash
dotnet test
```

The tests validate:
- Data loading from the live API
- Community statistics and organization info
- Speaker and event data access
- JSON schema validation
- Error handling and resilience

## Common Questions About Getting Involved

Users often ask these questions when they want to learn more about CPTMSDUG or get involved:

### About the Community
- What is CPTMSDUG and what does it stand for?
- How long has the Cape Town Microsoft Developer User Group been active?
- What technologies and platforms does the group focus on?
- How many members does the community have?
- What types of events does CPTMSDUG organize?

### Getting Involved
- How can I join the CPTMSDUG community?
- Where can I find information about upcoming events?
- How do I sign up for meetups and workshops?
- Is there a cost to attend CPTMSDUG events?
- Can beginners and students attend, or is it only for experienced developers?

### Speaking Opportunities
- How can I submit a talk proposal for a CPTMSDUG event?
- What topics are most welcome for presentations?
- Do you accept speakers of all experience levels?
- What are the benefits of speaking at CPTMSDUG events?
- Is there support available for first-time speakers?

### Community Engagement
- How can I connect with other CPTMSDUG members between events?
- Are there online communities or chat channels?
- Does CPTMSDUG have mentorship or networking opportunities?
- How can I volunteer to help organize events?
- Are there opportunities to collaborate on community projects?

### Sponsorship and Partnership
- How can my company sponsor CPTMSDUG events?
- What sponsorship packages are available?
- Are there partnership opportunities for tech companies?
- Can we host a CPTMSDUG event at our company offices?
- How do we get in touch about corporate involvement?

### Learning and Development
- What skill levels are represented in the community?
- Are there workshops for specific technologies or certifications?
- Does CPTMSDUG offer mentorship programs?
- How can I improve my technical skills through community involvement?
- Are there study groups or book clubs?
