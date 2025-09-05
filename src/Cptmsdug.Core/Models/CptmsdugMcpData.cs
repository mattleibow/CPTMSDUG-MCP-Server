using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class CptmsdugMcpData
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("website")]
    public Website Website { get; set; }

    [JsonPropertyName("organization")]
    public CommunityInformation Organization { get; set; }

    [JsonPropertyName("communityStats")]
    public CommunityStats CommunityStats { get; set; }

    [JsonPropertyName("mission")]
    public Mission Mission { get; set; }

    [JsonPropertyName("technologies")]
    public CommunityTechnologies Technologies { get; set; }

    [JsonPropertyName("events")]
    public EventInformation Events { get; set; }

    [JsonPropertyName("contact")]
    public Contact Contact { get; set; }

    [JsonPropertyName("organizers")]
    public List<Organizer> Organizers { get; set; }

    [JsonPropertyName("speakers")]
    public List<Speaker> Speakers { get; set; }

    [JsonPropertyName("speakingOpportunities")]
    public SessionSubmissionInformation SpeakingOpportunities { get; set; }

    [JsonPropertyName("speakerStatistics")]
    public CommunitySpeakerStatistics SpeakerStatistics { get; set; }

    [JsonPropertyName("websiteStructure")]
    public WebsiteStructure WebsiteStructure { get; set; }

    [JsonPropertyName("opportunities")]
    public Opportunities Opportunities { get; set; }

    [JsonPropertyName("technicalDetails")]
    public WebsiteTechnicalDetails TechnicalDetails { get; set; }

    [JsonPropertyName("meta")]
    public CptmsdugMcpDataMeta Meta { get; set; }
}

