using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class EventUpcoming
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;

    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("venue")]
    public string Venue { get; set; } = string.Empty;

    [JsonPropertyName("attendees")]
    public int Attendees { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("meetupUrl")]
    public string MeetupUrl { get; set; } = string.Empty;

    [JsonPropertyName("topics")]
    public List<string> Topics { get; set; } = new();

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new();

    [JsonPropertyName("abstract")]
    public string Abstract { get; set; } = string.Empty;

    [JsonPropertyName("agenda")]
    public List<Agendum> Agenda { get; set; } = new();

    [JsonPropertyName("collaboration")]
    public string Collaboration { get; set; } = string.Empty;

    [JsonPropertyName("requirements")]
    public string Requirements { get; set; } = string.Empty;

    [JsonPropertyName("speakers")]
    public List<EventSpeaker> Speakers { get; set; } = new();

    [JsonPropertyName("sessions")]
    public List<EventSession> Sessions { get; set; } = new();

    [JsonPropertyName("highlights")]
    public List<string> Highlights { get; set; } = new();

    [JsonPropertyName("dates")]
    public string Dates { get; set; } = string.Empty;

    [JsonPropertyName("cities")]
    public List<string> Cities { get; set; } = new();

    [JsonPropertyName("features")]
    public List<string> Features { get; set; } = new();

    [JsonPropertyName("expectedContent")]
    public List<string> ExpectedContent { get; set; } = new();
}

