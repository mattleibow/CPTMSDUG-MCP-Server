using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class CommunityStats
{
    [JsonPropertyName("members")]
    public int Members { get; set; }

    [JsonPropertyName("eventsHosted")]
    public int EventsHosted { get; set; }

    [JsonPropertyName("speakers")]
    public int Speakers { get; set; }

    [JsonPropertyName("yearsActive")]
    public int YearsActive { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("reviews")]
    public int Reviews { get; set; }
}

