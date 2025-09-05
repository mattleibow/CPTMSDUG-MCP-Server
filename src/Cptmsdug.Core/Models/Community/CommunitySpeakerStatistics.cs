using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class CommunitySpeakerStatistics
{
    [JsonPropertyName("totalSpeakers")]
    public int TotalSpeakers { get; set; }

    [JsonPropertyName("microsoftMVPs")]
    public int MicrosoftMVPs { get; set; }

    [JsonPropertyName("microsoftEmployees")]
    public int MicrosoftEmployees { get; set; }

    [JsonPropertyName("internationalSpeakers")]
    public int InternationalSpeakers { get; set; }

    [JsonPropertyName("localExperts")]
    public int LocalExperts { get; set; }
}

