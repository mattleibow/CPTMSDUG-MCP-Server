using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Organizer
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("social")]
    public OrganizerSocial Social { get; set; }
}

