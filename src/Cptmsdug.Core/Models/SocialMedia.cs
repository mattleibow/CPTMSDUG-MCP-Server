using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class SocialMedia
{
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; }

    [JsonPropertyName("linkedin")]
    public string LinkedIn { get; set; }

    [JsonPropertyName("meetup")]
    public string Meetup { get; set; }

    [JsonPropertyName("sessionize")]
    public string Sessionize { get; set; }

    [JsonPropertyName("discord")]
    public string Discord { get; set; }
}

