using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class EventStatistics
{
    [JsonPropertyName("tracks")]
    public int Tracks { get; set; }

    [JsonPropertyName("sessions")]
    public int Sessions { get; set; }

    [JsonPropertyName("attendeesPerCity")]
    public int? AttendeesPerCity { get; set; }

    [JsonPropertyName("attendeesTotal")]
    public int? AttendeesTotal { get; set; }

    [JsonPropertyName("speakers")]
    public int? Speakers { get; set; }

    [JsonPropertyName("cities")]
    public int? Cities { get; set; }

    [JsonPropertyName("swagPackages")]
    public int? SwagPackages { get; set; }

    [JsonPropertyName("communities")]
    public int? Communities { get; set; }
}

