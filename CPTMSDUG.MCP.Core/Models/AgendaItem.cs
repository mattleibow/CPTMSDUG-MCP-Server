using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class AgendaItem
{
    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("activity")]
    public string Activity { get; set; } = string.Empty;

    [JsonPropertyName("speaker")]
    public string? Speaker { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }
}