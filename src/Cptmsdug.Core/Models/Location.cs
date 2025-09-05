using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Location
{
    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }
}
