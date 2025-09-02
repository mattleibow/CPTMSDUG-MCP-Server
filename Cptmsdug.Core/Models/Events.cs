using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Events
{
    [JsonPropertyName("types")]
    public List<string> Types { get; set; } = new();

    [JsonPropertyName("format")]
    public EventFormat Format { get; set; } = new();

    [JsonPropertyName("upcomingEvents")]
    public List<UpcomingEvent> UpcomingEvents { get; set; } = new();
}