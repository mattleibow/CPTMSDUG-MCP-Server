using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class Event
{
    [JsonPropertyName("date")]
    public EventDate Date { get; set; } = new();

    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("venue")]
    public string Venue { get; set; } = string.Empty;

    [JsonPropertyName("attendees")]
    public int? Attendees { get; set; }

    [JsonPropertyName("time_range")]
    public string TimeRange { get; set; } = string.Empty;

    [JsonPropertyName("badges")]
    public List<string> Badges { get; set; } = new();

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;

    [JsonPropertyName("image_alt")]
    public string ImageAlt { get; set; } = string.Empty;
}

public class EventDate
{
    [JsonPropertyName("day")]
    public string Day { get; set; } = string.Empty;

    [JsonPropertyName("month")]
    public string Month { get; set; } = string.Empty;

    [JsonPropertyName("year")]
    public string Year { get; set; } = string.Empty;

    [JsonPropertyName("formatted")]
    public string Formatted { get; set; } = string.Empty;
}