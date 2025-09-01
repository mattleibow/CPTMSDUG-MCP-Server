using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class Summary
{
    [JsonPropertyName("total_events")]
    public int TotalEvents { get; set; }

    [JsonPropertyName("total_speakers")]
    public int TotalSpeakers { get; set; }

    [JsonPropertyName("total_conferences")]
    public int TotalConferences { get; set; }

    [JsonPropertyName("total_pages_scraped")]
    public int TotalPagesScraped { get; set; }

    [JsonPropertyName("upcoming_events")]
    public int UpcomingEvents { get; set; }

    [JsonPropertyName("events_with_venues")]
    public int EventsWithVenues { get; set; }

    [JsonPropertyName("events_with_attendee_counts")]
    public int EventsWithAttendeeCounts { get; set; }
}