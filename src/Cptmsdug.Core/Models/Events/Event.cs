using System.Text.Json.Serialization;
using Cptmsdug.Core.Converters;

namespace Cptmsdug.Core.Models;

public class Event
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("startDateTime")]
    [JsonConverter(typeof(NullableSastDateTimeOffsetConverter))]
    public DateTimeOffset? StartDateTime { get; set; }

    [JsonPropertyName("endDateTime")]
    [JsonConverter(typeof(NullableSastDateTimeOffsetConverter))]
    public DateTimeOffset? EndDateTime { get; set; }

    [JsonPropertyName("venue")]
    public string Venue { get; set; }

    [JsonPropertyName("attendees")]
    public int Attendees { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("eventType")]
    public string EventType { get; set; }

    [JsonPropertyName("meetupUrl")]
    public string MeetupUrl { get; set; }

    [JsonPropertyName("topics")]
    public List<string> Topics { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("abstract")]
    public string Abstract { get; set; }

    [JsonPropertyName("agenda")]
    public List<EventAgendaItem> Agenda { get; set; }

    [JsonPropertyName("collaboration")]
    public string Collaboration { get; set; }

    [JsonPropertyName("requirements")]
    public string Requirements { get; set; }

    [JsonPropertyName("speakers")]
    public List<Speaker> Speakers { get; set; }

    [JsonPropertyName("sessions")]
    public List<EventSession> Sessions { get; set; }

    [JsonPropertyName("highlights")]
    public List<string> Highlights { get; set; }

    [JsonPropertyName("cities")]
    public List<string> Cities { get; set; }

    [JsonPropertyName("features")]
    public List<string> Features { get; set; }

    [JsonPropertyName("expectedContent")]
    public List<string> ExpectedContent { get; set; }

    [JsonPropertyName("keyTopics")]
    public List<string> KeyTopics { get; set; }

    [JsonPropertyName("stats")]
    public EventStatistics Stats { get; set; }

    [JsonPropertyName("websiteUrl")]
    public string WebsiteUrl { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("tracks")]
    public List<string> Tracks { get; set; }

    [JsonPropertyName("speaker")]
    public string Speaker { get; set; }

    // Computed properties for parsed dates
    [JsonIgnore]
    public DateTimeOffset? StartTime => StartDateTime;

    [JsonIgnore]
    public DateTimeOffset? EndTime => EndDateTime;

    // Computed properties for event status
    [JsonIgnore]
    public bool IsUpcoming => StartTime.HasValue && StartTime.Value > DateTimeOffset.UtcNow;

    [JsonIgnore]
    public bool IsPast => StartTime.HasValue && StartTime.Value <= DateTimeOffset.UtcNow;

    // Computed property that merges all speaker sources
    [JsonIgnore]
    public List<Speaker> AllSpeakers => GetAllSpeakers();

    private List<Speaker> GetAllSpeakers()
    {
        var allSpeakers = new List<Speaker>();

        // Add speakers from the Speakers collection (detailed speaker objects)
        if (Speakers != null)
        {
            allSpeakers.AddRange(Speakers);
        }

        // Create speaker objects from session speakers (string names only)
        if (Sessions != null)
        {
            foreach (var session in Sessions)
            {
                if (!string.IsNullOrEmpty(session.Speaker))
                {
                    // Check if we already have this speaker from the Speakers collection
                    if (!allSpeakers.Any(s => string.Equals(s.Name, session.Speaker, StringComparison.OrdinalIgnoreCase)))
                    {
                        allSpeakers.Add(new Speaker { Name = session.Speaker });
                    }
                }
            }
        }

        // Create speaker object from the direct Speaker property (string name only)
        if (!string.IsNullOrEmpty(Speaker))
        {
            // Check if we already have this speaker
            if (!allSpeakers.Any(s => string.Equals(s.Name, Speaker, StringComparison.OrdinalIgnoreCase)))
            {
                allSpeakers.Add(new Speaker { Name = Speaker });
            }
        }

        return allSpeakers;
    }
}

