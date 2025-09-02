using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

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