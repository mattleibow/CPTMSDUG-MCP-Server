using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class UserGroup
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("acronym")]
    public string Acronym { get; set; } = string.Empty;

    [JsonPropertyName("website")]
    public string Website { get; set; } = string.Empty;

    [JsonPropertyName("scraped_at")]
    public string ScrapedAt { get; set; } = string.Empty;

    [JsonPropertyName("member_count")]
    public string MemberCount { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("social_links")]
    public SocialLinks SocialLinks { get; set; } = new();
}

public class SocialLinks
{
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; } = string.Empty;

    [JsonPropertyName("meetup")]
    public string Meetup { get; set; } = string.Empty;
}