using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class CptmsdugData
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public string Version { get; set; } = string.Empty;

    [JsonPropertyName("website")]
    public Website Website { get; set; } = new();

    [JsonPropertyName("organization")]
    public Organization Organization { get; set; } = new();

    [JsonPropertyName("communityStats")]
    public CommunityStats CommunityStats { get; set; } = new();

    [JsonPropertyName("mission")]
    public Mission Mission { get; set; } = new();

    [JsonPropertyName("technologies")]
    public Technologies Technologies { get; set; } = new();

    [JsonPropertyName("events")]
    public Events Events { get; set; } = new();

    [JsonPropertyName("contact")]
    public Contact Contact { get; set; } = new();

    [JsonPropertyName("opportunities")]
    public Opportunities Opportunities { get; set; } = new();

    [JsonPropertyName("organizers")]
    public List<Organizer> Organizers { get; set; } = new();

    [JsonPropertyName("speakers")]
    public List<Speaker> Speakers { get; set; } = new();

    [JsonPropertyName("speakerStatistics")]
    public SpeakerStatistics SpeakerStatistics { get; set; } = new();

    [JsonPropertyName("speakingOpportunities")]
    public SpeakingOpportunities SpeakingOpportunities { get; set; } = new();

    [JsonPropertyName("technicalDetails")]
    public TechnicalDetails TechnicalDetails { get; set; } = new();

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; } = new();

    [JsonPropertyName("websiteStructure")]
    public WebsiteStructure WebsiteStructure { get; set; } = new();
}