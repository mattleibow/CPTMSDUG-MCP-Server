using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class Conference
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("subtitle")]
    public string Subtitle { get; set; } = string.Empty;
    
    [JsonPropertyName("dates")]
    public string[] Dates { get; set; } = Array.Empty<string>();
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("statistics")]
    public ConferenceStatistics? Statistics { get; set; }
    
    [JsonPropertyName("key_topics")]
    public string[] KeyTopics { get; set; } = Array.Empty<string>();
    
    [JsonPropertyName("details_url")]
    public string DetailsUrl { get; set; } = string.Empty;
}

public class ConferenceStatistics
{
    [JsonPropertyName("attendees")]
    public string Attendees { get; set; } = string.Empty;
    
    [JsonPropertyName("track")]
    public string Track { get; set; } = string.Empty;
    
    [JsonPropertyName("sessions")]
    public string Sessions { get; set; } = string.Empty;
    
    [JsonPropertyName("attendees_per_city")]
    public string AttendeesPerCity { get; set; } = string.Empty;
    
    [JsonPropertyName("tracks")]
    public string Tracks { get; set; } = string.Empty;
    
    [JsonPropertyName("expert_speakers")]
    public string ExpertSpeakers { get; set; } = string.Empty;
    
    [JsonPropertyName("cities")]
    public string Cities { get; set; } = string.Empty;
    
    [JsonPropertyName("speakers")]
    public string Speakers { get; set; } = string.Empty;
    
    [JsonPropertyName("swag_packages")]
    public string SwagPackages { get; set; } = string.Empty;
}