using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class OrganizerSocial
{
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; }

    [JsonPropertyName("linkedin")]
    public string LinkedIn { get; set; }

    [JsonPropertyName("github")]
    public string Github { get; set; }
}

