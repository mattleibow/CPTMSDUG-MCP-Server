using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Opportunities
{
    [JsonPropertyName("speaking")]
    public SpeakingOpportunity Speaking { get; set; } = new();

    [JsonPropertyName("sponsorship")]
    public SponsorshipOpportunity Sponsorship { get; set; } = new();

    [JsonPropertyName("volunteering")]
    public VolunteeringOpportunity Volunteering { get; set; } = new();
}