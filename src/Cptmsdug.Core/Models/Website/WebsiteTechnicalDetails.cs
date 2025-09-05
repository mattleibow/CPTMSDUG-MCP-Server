using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class WebsiteTechnicalDetails
{
    [JsonPropertyName("websiteTech")]
    public List<string> WebsiteTech { get; set; }

    [JsonPropertyName("features")]
    public List<string> Features { get; set; }
}

