using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Organizer
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("social")]
    public OrganizerSocial Social { get; set; } = new();
}