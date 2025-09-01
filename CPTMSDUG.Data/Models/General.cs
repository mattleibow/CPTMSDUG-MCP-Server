using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class General
{
    [JsonPropertyName("organization")]
    public string Organization { get; set; } = string.Empty;
    
    [JsonPropertyName("abbreviation")]
    public string Abbreviation { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("member_count")]
    public string? MemberCount { get; set; }
    
    [JsonPropertyName("website")]
    public string Website { get; set; } = string.Empty;
    
    [JsonPropertyName("location")]
    public string Location { get; set; } = string.Empty;
    
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; } = string.Empty;
    
    [JsonPropertyName("meetup_group")]
    public string MeetupGroup { get; set; } = string.Empty;
    
    [JsonPropertyName("mission")]
    public string Mission { get; set; } = string.Empty;
    
    [JsonPropertyName("statistics")]
    public OrganizationStatistics? Statistics { get; set; }
    
    [JsonPropertyName("core_values")]
    public CoreValue[] CoreValues { get; set; } = Array.Empty<CoreValue>();
    
    [JsonPropertyName("technologies_focus")]
    public TechnologyFocus[] TechnologiesFocus { get; set; } = Array.Empty<TechnologyFocus>();
    
    [JsonPropertyName("social_media")]
    public SocialMedia? SocialMedia { get; set; }
    
    [JsonPropertyName("emails")]
    public string[] Emails { get; set; } = Array.Empty<string>();
}

public class OrganizationStatistics
{
    [JsonPropertyName("total_members")]
    public string TotalMembers { get; set; } = string.Empty;
    
    [JsonPropertyName("events_hosted")]
    public string EventsHosted { get; set; } = string.Empty;
    
    [JsonPropertyName("years_active")]
    public string YearsActive { get; set; } = string.Empty;
    
    [JsonPropertyName("speakers")]
    public string Speakers { get; set; } = string.Empty;
}

public class CoreValue
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

public class TechnologyFocus
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

public class SocialMedia
{
    [JsonPropertyName("meetup")]
    public string Meetup { get; set; } = string.Empty;
    
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; } = string.Empty;
    
    [JsonPropertyName("linkedin")]
    public string LinkedIn { get; set; } = string.Empty;
    
    [JsonPropertyName("sessionize")]
    public string Sessionize { get; set; } = string.Empty;
}