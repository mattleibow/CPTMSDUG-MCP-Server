using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class SponsorshipOpportunity
{
    [JsonPropertyName("types")]
    public List<string> Types { get; set; } = new();

    [JsonPropertyName("contact")]
    public string Contact { get; set; } = string.Empty;
}