using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class SponsorshipOpportunities
{
    [JsonPropertyName("types")]
    public List<string> Types { get; set; }

    [JsonPropertyName("contact")]
    public string Contact { get; set; }
}

