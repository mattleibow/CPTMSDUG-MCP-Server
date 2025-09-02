using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class Opportunities
{
    [JsonPropertyName("speaking")]
    public SpeakingOpportunity Speaking { get; set; } = new();

    [JsonPropertyName("sponsorship")]
    public SponsorshipOpportunity Sponsorship { get; set; } = new();

    [JsonPropertyName("volunteering")]
    public VolunteeringOpportunity Volunteering { get; set; } = new();
}

public class SpeakingOpportunity
{
    [JsonPropertyName("topics")]
    public List<string> Topics { get; set; } = new();

    [JsonPropertyName("benefits")]
    public List<string> Benefits { get; set; } = new();

    [JsonPropertyName("submission")]
    public string Submission { get; set; } = string.Empty;
}

public class SponsorshipOpportunity
{
    [JsonPropertyName("types")]
    public List<string> Types { get; set; } = new();

    [JsonPropertyName("contact")]
    public string Contact { get; set; } = string.Empty;
}

public class VolunteeringOpportunity
{
    [JsonPropertyName("roles")]
    public List<string> Roles { get; set; } = new();

    [JsonPropertyName("contact")]
    public string Contact { get; set; } = string.Empty;
}

public class SpeakerStatistics
{
    [JsonPropertyName("totalSpeakers")]
    public string TotalSpeakers { get; set; } = string.Empty;

    [JsonPropertyName("microsoftMVPs")]
    public int MicrosoftMVPs { get; set; }

    [JsonPropertyName("microsoftEmployees")]
    public int MicrosoftEmployees { get; set; }

    [JsonPropertyName("internationalSpeakers")]
    public int InternationalSpeakers { get; set; }

    [JsonPropertyName("localExperts")]
    public int LocalExperts { get; set; }
}

public class SpeakingOpportunities
{
    [JsonPropertyName("callForSpeakers")]
    public bool CallForSpeakers { get; set; }

    [JsonPropertyName("sessionizeUrl")]
    public string SessionizeUrl { get; set; } = string.Empty;

    [JsonPropertyName("contactEmail")]
    public string ContactEmail { get; set; } = string.Empty;

    [JsonPropertyName("welcomedTopics")]
    public List<string> WelcomedTopics { get; set; } = new();

    [JsonPropertyName("speakerBenefits")]
    public List<string> SpeakerBenefits { get; set; } = new();

    [JsonPropertyName("experienceLevels")]
    public string ExperienceLevels { get; set; } = string.Empty;
}

public class TechnicalDetails
{
    [JsonPropertyName("websiteTech")]
    public List<string> WebsiteTech { get; set; } = new();

    [JsonPropertyName("features")]
    public List<string> Features { get; set; } = new();
}

public class Meta
{
    [JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public string Version { get; set; } = string.Empty;

    [JsonPropertyName("schemaVersion")]
    public string SchemaVersion { get; set; } = string.Empty;

    [JsonPropertyName("dataSource")]
    public string DataSource { get; set; } = string.Empty;

    [JsonPropertyName("maintainer")]
    public string Maintainer { get; set; } = string.Empty;

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; } = string.Empty;
}

public class WebsiteStructure
{
    [JsonPropertyName("pages")]
    public List<WebPage> Pages { get; set; } = new();
}

public class WebPage
{
    [JsonPropertyName("path")]
    public string Path { get; set; } = string.Empty;

    [JsonPropertyName("file")]
    public string File { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}