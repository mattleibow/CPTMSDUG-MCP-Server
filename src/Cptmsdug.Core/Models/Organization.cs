using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Organization
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("shortName")]
    public string ShortName { get; set; }

    [JsonPropertyName("handle")]
    public string Handle { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }

    [JsonPropertyName("founded")]
    public string Founded { get; set; }

    [JsonPropertyName("yearsActive")]
    public string YearsActive { get; set; }

    [JsonPropertyName("affiliations")]
    public List<string> Affiliations { get; set; }
}

