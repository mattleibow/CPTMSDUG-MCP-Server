using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Opportunities
{
    [JsonPropertyName("speaking")]
    public SpeakingOpportunities Speaking { get; set; }

    [JsonPropertyName("sponsorship")]
    public SponsorshipOpportunities Sponsorship { get; set; }

    [JsonPropertyName("volunteering")]
    public VolunteeringOpportunities Volunteering { get; set; }
}

