using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class SpeakingOpportunity
{
    [JsonPropertyName("topics")]
    public List<string> Topics { get; set; } = new();

    [JsonPropertyName("benefits")]
    public List<string> Benefits { get; set; } = new();

    [JsonPropertyName("submission")]
    public string Submission { get; set; } = string.Empty;
}