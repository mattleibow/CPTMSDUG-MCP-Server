using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class CommunityStats
{
    [JsonPropertyName("members")]
    public int Members { get; set; }

    [JsonPropertyName("eventsHosted")]
    public string EventsHosted { get; set; } = string.Empty;

    [JsonPropertyName("speakers")]
    public string Speakers { get; set; } = string.Empty;

    [JsonPropertyName("yearsActive")]
    public string YearsActive { get; set; } = string.Empty;

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("reviews")]
    public int Reviews { get; set; }
}