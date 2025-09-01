# CPTMSDUG.Data Library

A C# library for loading and accessing CPTMSDUG (Cape Town Microsoft Developer User Group) data from JSON files.

## Features

- **Type-safe models** for all CPTMSDUG data structures
- **In-memory data store** for fast access to loaded data
- **Query methods** for common data access patterns
- **Async loading** for better performance
- **JSON serialization** using System.Text.Json

## Data Models

The library includes models for:

- **Events**: Upcoming meetups and conferences
- **Speakers**: Speaker profiles with expertise areas
- **Conferences**: Past and upcoming conferences with statistics
- **General**: Organization information, mission, and social media
- **Metadata**: Data extraction information and structure documentation

## Usage

```csharp
using CPTMSDUG.Data;

// Initialize the data store with path to data directory
var dataStore = new CPTMSDUGDataStore("/path/to/data");

// Load all data from JSON files
await dataStore.LoadAllDataAsync();

// Access organization information
Console.WriteLine($"Organization: {dataStore.General?.Organization}");
Console.WriteLine($"Members: {dataStore.General?.Statistics?.TotalMembers}");

// Query events
var upcomingEvents = dataStore.GetUpcomingEvents();
var meetups = dataStore.GetMeetups();

// Find speakers by expertise
var mvpSpeakers = dataStore.GetSpeakersByExpertise("MVP");
var speaker = dataStore.GetSpeakerByName("Richard Campbell");

// Search conferences
var dotnetConf = dataStore.GetConferenceByName(".NET Conf");
```

## Data Structure

The library expects JSON files in the following structure:

- `events.json` - Array of event objects
- `speakers.json` - Array of speaker objects  
- `conferences.json` - Array of conference objects
- `general.json` - Single organization object
- `metadata.json` - Single metadata object

## Dependencies

- .NET 8.0
- System.Text.Json (included in .NET)

## Building

```bash
dotnet build
```

## Testing

See the `CPTMSDUG.Data.Example` project for a working example of how to use the library.