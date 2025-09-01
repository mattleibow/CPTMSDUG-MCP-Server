using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class Event
{
    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;
    
    [JsonPropertyName("date_parts")]
    public DateParts? DateParts { get; set; }
    
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
    
    [JsonPropertyName("rsvp_url")]
    public string RsvpUrl { get; set; } = string.Empty;
    
    [JsonPropertyName("sold_out")]
    public bool SoldOut { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    
    [JsonPropertyName("locations")]
    public string[]? Locations { get; set; }
    
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
    
    [JsonPropertyName("features")]
    public Feature[]? Features { get; set; }
}

public class DateParts
{
    [JsonPropertyName("day")]
    public string Day { get; set; } = string.Empty;
    
    [JsonPropertyName("month")]
    public string Month { get; set; } = string.Empty;
    
    [JsonPropertyName("year")]
    public string Year { get; set; } = string.Empty;
}

public class Feature
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}