using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Speaker
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("company")]
    public string Company { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("sessions")]
    public List<string> Sessions { get; set; } = new();

    [JsonPropertyName("specialties")]
    public List<string> Specialties { get; set; } = new();

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new();

    [JsonPropertyName("events")]
    public List<string> Events { get; set; } = new();
}