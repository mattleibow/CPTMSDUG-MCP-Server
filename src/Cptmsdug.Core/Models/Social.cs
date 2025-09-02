using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Social
{
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; } = string.Empty;

    [JsonPropertyName("linkedin")]
    public string LinkedIn { get; set; } = string.Empty;

    [JsonPropertyName("github")]
    public string GitHub { get; set; } = string.Empty;
}

