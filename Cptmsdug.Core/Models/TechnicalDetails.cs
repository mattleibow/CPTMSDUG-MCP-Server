using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class TechnicalDetails
{
    [JsonPropertyName("websiteTech")]
    public List<string> WebsiteTech { get; set; } = new();

    [JsonPropertyName("features")]
    public List<string> Features { get; set; } = new();
}