using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Opportunities
{
    [JsonPropertyName("speaking")]
    public Speaking Speaking { get; set; } = new();

    [JsonPropertyName("sponsorship")]
    public Sponsorship Sponsorship { get; set; } = new();

    [JsonPropertyName("volunteering")]
    public Volunteering Volunteering { get; set; } = new();
}

