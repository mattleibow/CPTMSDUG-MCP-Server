using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class EventInformation
{
    [JsonPropertyName("types")]
    public List<string> Types { get; set; }

    [JsonPropertyName("format")]
    public EventFormat Format { get; set; }

    [JsonPropertyName("allEvents")]
    public List<Event> AllEvents { get; set; }
}

