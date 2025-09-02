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

public class Website
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("tagline")]
    public string Tagline { get; set; } = string.Empty;
}

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

public class Location
{
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("region")]
    public string Region { get; set; } = string.Empty;
}

public class CommunityStats
{
    [JsonPropertyName("members")]
    public int Members { get; set; }

    [JsonPropertyName("eventsHosted")]
    public string EventsHosted { get; set; } = string.Empty;

    [JsonPropertyName("speakers")]
    public string Speakers { get; set; } = string.Empty;

    [JsonPropertyName("yearsActive")]
    public string YearsActive { get; set; } = string.Empty;

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("reviews")]
    public int Reviews { get; set; }
}

public class Mission
{
    [JsonPropertyName("primary")]
    public string Primary { get; set; } = string.Empty;

    [JsonPropertyName("secondary")]
    public string Secondary { get; set; } = string.Empty;

    [JsonPropertyName("values")]
    public List<string> Values { get; set; } = new();
}

public class Technologies
{
    [JsonPropertyName("primary")]
    public List<string> Primary { get; set; } = new();

    [JsonPropertyName("secondary")]
    public List<string> Secondary { get; set; } = new();
}