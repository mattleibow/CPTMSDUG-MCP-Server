using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class OrganizerSocial
{
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; } = string.Empty;

    [JsonPropertyName("linkedin")]
    public string LinkedIn { get; set; } = string.Empty;
}