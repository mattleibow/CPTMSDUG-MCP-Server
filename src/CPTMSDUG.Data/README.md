# CPTMSDUG Data Library

A C# library for loading and accessing data from the Cape Town MS Developer User Group (CPTMSDUG) JSON data files.

## Features

- **Type-safe models** for all CPTMSDUG data structures (Events, Speakers, Conferences, etc.)
- **In-memory data store** for fast access to loaded data
- **JSON deserialization** using System.Text.Json
- **Simple API** for accessing different data types
- **Comprehensive test coverage**

## Installation

Add a reference to the `CPTMSDUG.Data` project in your solution:

```bash
dotnet add reference path/to/CPTMSDUG.Data.csproj
```

## Usage

### Basic Usage

```csharp
using CPTMSDUG.Data.Services;

// Create the data service
var dataService = new CptmsdugDataService();

// Load data from JSON file
var data = await dataService.LoadDataAsync("path/to/cptmsdug_data.json");

// Access user group information
var userGroup = dataService.GetUserGroup();
Console.WriteLine($"Group: {userGroup.Name} ({userGroup.Acronym})");

// Get events
var events = dataService.GetEvents();
foreach (var evt in events)
{
    Console.WriteLine($"{evt.Title} - {evt.Date.Formatted}");
}

// Get speakers
var speakers = dataService.GetSpeakers();
foreach (var speaker in speakers)
{
    Console.WriteLine($"{speaker.Name}: {speaker.Bio}");
}
```

### Available Data Access Methods

The `ICptmsdugDataService` interface provides the following methods:

- `LoadDataAsync(string filePath)` - Load data from JSON file
- `GetCachedData()` - Get the full loaded data object
- `GetUserGroup()` - Get user group information
- `GetEvents()` - Get list of events
- `GetSpeakers()` - Get list of speakers  
- `GetConferences()` - Get list of conferences
- `GetDotNetConf()` - Get .NET conference information
- `GetContact()` - Get contact information
- `GetSummary()` - Get summary statistics
- `GetPages()` - Get page information

### Data Models

The library includes strongly-typed models for all data structures:

- `CptmsdugData` - Root data object
- `UserGroup` - User group information with social links
- `Event` - Event details with date, venue, attendees, etc.
- `Speaker` - Speaker information with bio and image
- `Conference` - Conference details
- `DotNetConf` - .NET conference specific information
- `Contact` - Contact information
- `Summary` - Summary statistics
- `Pages` - Page metadata

## Building and Testing

Build the solution:
```bash
dotnet build
```

Run tests:
```bash
dotnet test
```

Run the demo application:
```bash
cd examples/CPTMSDUG.Demo
dotnet run
```

## Example Output

The demo application produces output like:

```
CPTMSDUG Data Library Demo
==========================
Loading data from: /path/to/cptmsdug_data.json
Data loaded successfully!

User Group: Cape Town MS Developer User Group
Acronym: CPTMSDUG
Website: https://cptmsdug.dev
Member Count: 1,875
Twitter: @CPTMSDUG

Upcoming Events (5):
  - VS Code Dev Days - Cape Town
    Date: 13 SEP 2025
    Venue: Microsoft Cape Town, Pinelands
    Attendees: 60
...
```

## Dependencies

- .NET 8.0
- System.Text.Json 9.0.8

## Project Structure

```
src/
  CPTMSDUG.Data/           # Main library
    Models/                # Data models
    Services/              # Data service implementation
tests/
  CPTMSDUG.Data.Tests/     # Unit tests
examples/
  CPTMSDUG.Demo/           # Demo console application
data/
  cptmsdug_data.json       # Sample data file
```