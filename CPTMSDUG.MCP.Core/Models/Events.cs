using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class Events
{
    [JsonPropertyName("types")]
    public List<string> Types { get; set; } = new();

    [JsonPropertyName("format")]
    public EventFormat Format { get; set; } = new();

    [JsonPropertyName("upcomingEvents")]
    public List<UpcomingEvent> UpcomingEvents { get; set; } = new();
}

public class EventFormat
{
    [JsonPropertyName("duration")]
    public string Duration { get; set; } = string.Empty;

    [JsonPropertyName("frequency")]
    public string Frequency { get; set; } = string.Empty;

    [JsonPropertyName("venues")]
    public List<string> Venues { get; set; } = new();

    [JsonPropertyName("capacity")]
    public string Capacity { get; set; } = string.Empty;
}

public class UpcomingEvent
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;

    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("venue")]
    public string Venue { get; set; } = string.Empty;

    [JsonPropertyName("attendees")]
    public int Attendees { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("meetupUrl")]
    public string MeetupUrl { get; set; } = string.Empty;

    [JsonPropertyName("topics")]
    public List<string> Topics { get; set; } = new();

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new();

    [JsonPropertyName("abstract")]
    public string Abstract { get; set; } = string.Empty;

    [JsonPropertyName("agenda")]
    public List<AgendaItem> Agenda { get; set; } = new();

    [JsonPropertyName("speakers")]
    public List<EventSpeaker> Speakers { get; set; } = new();

    [JsonPropertyName("requirements")]
    public string? Requirements { get; set; }

    [JsonPropertyName("collaboration")]
    public string? Collaboration { get; set; }
}

public class AgendaItem
{
    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("activity")]
    public string Activity { get; set; } = string.Empty;

    [JsonPropertyName("speaker")]
    public string? Speaker { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }
}

public class EventSpeaker
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;

    [JsonPropertyName("company")]
    public string Company { get; set; } = string.Empty;

    [JsonPropertyName("topic")]
    public string Topic { get; set; } = string.Empty;
}