using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class Mission
{
    [JsonPropertyName("primary")]
    public string Primary { get; set; } = string.Empty;

    [JsonPropertyName("secondary")]
    public string Secondary { get; set; } = string.Empty;

    [JsonPropertyName("values")]
    public List<string> Values { get; set; } = new();
}