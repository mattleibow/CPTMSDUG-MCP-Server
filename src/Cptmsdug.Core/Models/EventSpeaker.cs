using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class EventSpeaker
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("specialties")]
    public List<string> Specialties { get; set; }

    [JsonPropertyName("mvp")]
    public bool Mvp { get; set; }

    [JsonPropertyName("experience")]
    public string Experience { get; set; }

    [JsonPropertyName("sessions")]
    public List<string> Sessions { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("events")]
    public List<string> Events { get; set; }

    [JsonPropertyName("upcomingEvents")]
    public List<string> UpcomingEvents { get; set; }

    [JsonPropertyName("achievements")]
    public List<string> Achievements { get; set; }
}

