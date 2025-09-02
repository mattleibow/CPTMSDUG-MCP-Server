using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class ContactEmail
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

