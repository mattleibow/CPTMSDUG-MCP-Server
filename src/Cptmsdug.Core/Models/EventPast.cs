using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class EventPast
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;

    [JsonPropertyName("attendees")]
    public int Attendees { get; set; }

    [JsonPropertyName("meetupUrl")]
    public string MeetupUrl { get; set; } = string.Empty;

    [JsonPropertyName("topics")]
    public List<string> Topics { get; set; } = new();

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new();

    [JsonPropertyName("abstract")]
    public string Abstract { get; set; } = string.Empty;

    [JsonPropertyName("speaker")]
    public string Speaker { get; set; } = string.Empty;

    [JsonPropertyName("sessions")]
    public List<EventSession> Sessions { get; set; } = new();

    [JsonPropertyName("venue")]
    public string Venue { get; set; } = string.Empty;
}

