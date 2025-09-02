using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class EmailContacts
{
    [JsonPropertyName("general")]
    public string General { get; set; } = string.Empty;

    [JsonPropertyName("speakers")]
    public string Speakers { get; set; } = string.Empty;

    [JsonPropertyName("sponsors")]
    public string Sponsors { get; set; } = string.Empty;

    [JsonPropertyName("volunteers")]
    public string Volunteers { get; set; } = string.Empty;
}