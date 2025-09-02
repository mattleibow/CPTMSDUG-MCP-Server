using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class SocialMedia
{
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; } = string.Empty;

    [JsonPropertyName("linkedin")]
    public string LinkedIn { get; set; } = string.Empty;

    [JsonPropertyName("meetup")]
    public string Meetup { get; set; } = string.Empty;

    [JsonPropertyName("sessionize")]
    public string Sessionize { get; set; } = string.Empty;

    [JsonPropertyName("discord")]
    public string Discord { get; set; } = string.Empty;
}