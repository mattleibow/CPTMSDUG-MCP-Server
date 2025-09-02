using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Events
{
    [JsonPropertyName("types")]
    public List<string> Types { get; set; } = new();

    [JsonPropertyName("format")]
    public EventFormat Format { get; set; } = new();

    [JsonPropertyName("upcomingEvents")]
    public List<EventUpcoming> UpcomingEvents { get; set; } = new();

    [JsonPropertyName("pastEvents")]
    public List<EventPast> PastEvents { get; set; } = new();
}

