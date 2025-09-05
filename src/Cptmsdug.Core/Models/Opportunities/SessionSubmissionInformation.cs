using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class SessionSubmissionInformation
{
    [JsonPropertyName("callForSpeakers")]
    public bool CallForSpeakers { get; set; }

    [JsonPropertyName("sessionizeUrl")]
    public string SessionizeUrl { get; set; }

    [JsonPropertyName("contactEmail")]
    public string ContactEmail { get; set; }

    [JsonPropertyName("welcomedTopics")]
    public List<string> WelcomedTopics { get; set; }

    [JsonPropertyName("speakerBenefits")]
    public List<string> SpeakerBenefits { get; set; }

    [JsonPropertyName("experienceLevels")]
    public string ExperienceLevels { get; set; }
}

