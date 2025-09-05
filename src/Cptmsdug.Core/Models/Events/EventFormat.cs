using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class EventFormat
{
    [JsonPropertyName("duration")]
    public string Duration { get; set; }

    [JsonPropertyName("frequency")]
    public string Frequency { get; set; }

    [JsonPropertyName("venues")]
    public List<string> Venues { get; set; }

    [JsonPropertyName("capacity")]
    public string Capacity { get; set; }
}

