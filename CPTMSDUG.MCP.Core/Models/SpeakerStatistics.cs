using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class SpeakerStatistics
{
    [JsonPropertyName("totalSpeakers")]
    public string TotalSpeakers { get; set; } = string.Empty;

    [JsonPropertyName("microsoftMVPs")]
    public int MicrosoftMVPs { get; set; }

    [JsonPropertyName("microsoftEmployees")]
    public int MicrosoftEmployees { get; set; }

    [JsonPropertyName("internationalSpeakers")]
    public int InternationalSpeakers { get; set; }

    [JsonPropertyName("localExperts")]
    public int LocalExperts { get; set; }
}