using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Organization
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("shortName")]
    public string ShortName { get; set; } = string.Empty;

    [JsonPropertyName("handle")]
    public string Handle { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("location")]
    public Location Location { get; set; } = new();

    [JsonPropertyName("founded")]
    public string Founded { get; set; } = string.Empty;

    [JsonPropertyName("yearsActive")]
    public string YearsActive { get; set; } = string.Empty;

    [JsonPropertyName("affiliations")]
    public List<string> Affiliations { get; set; } = new();
}