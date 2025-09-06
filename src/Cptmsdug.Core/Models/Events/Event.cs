using System.Text.Json.Serialization;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Cptmsdug.Core.Models;

public class Event
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("dates")]
    public string Dates { get; set; }

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
    public DateTimeOffset? StartTime => ParseStartTime();

    [JsonIgnore]
    public DateTimeOffset? EndTime => ParseEndTime();

    // Computed properties for event status
    [JsonIgnore]
    public bool IsUpcoming => StartTime.HasValue && StartTime.Value > DateTimeOffset.UtcNow;

    [JsonIgnore]
    public bool IsPast => StartTime.HasValue && StartTime.Value <= DateTimeOffset.UtcNow;

    // Computed property that merges all speaker sources
    [JsonIgnore]
    public List<Speaker> AllSpeakers => GetAllSpeakers();

    private DateTimeOffset? ParseStartTime()
    {
        // Format 1: Separate "date" and "time" fields
        if (!string.IsNullOrEmpty(Date) && Date != string.Empty)
        {
            if (DateTime.TryParseExact(Date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                if (!string.IsNullOrEmpty(Time) && Time != string.Empty)
                {
                    // Parse time like "9:00 AM SAST" or "5:30 PM SAST"
                    var timeWithoutSAST = Time.Replace(" SAST", "").Trim();
                    if (DateTime.TryParseExact(timeWithoutSAST, new[] { "h:mm tt", "hh:mm tt" }, 
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedTime))
                    {
                        var combined = parsedDate.Date + parsedTime.TimeOfDay;
                        // SAST is UTC+2
                        return new DateTimeOffset(combined, TimeSpan.FromHours(2));
                    }
                }
                // Date only, use start of day SAST
                return new DateTimeOffset(parsedDate, TimeSpan.FromHours(2));
            }
        }

        // For "dates" field, get the first date
        if (!string.IsNullOrEmpty(Dates) && Dates != string.Empty)
        {
            var parsedDates = ParseDatesField();
            return parsedDates.Count > 0 ? parsedDates.First() : null;
        }

        return null;
    }

    private DateTimeOffset? ParseEndTime()
    {
        // For single date events, end time is same as start time (unless we have duration info)
        if (!string.IsNullOrEmpty(Date) && Date != string.Empty)
        {
            return StartTime; // Same day events
        }

        // For "dates" field, get the last date
        if (!string.IsNullOrEmpty(Dates) && Dates != string.Empty)
        {
            var parsedDates = ParseDatesField();
            return parsedDates.Count > 0 ? parsedDates.Last() : null;
        }

        return null;
    }

    private List<DateTimeOffset> ParseDatesField()
    {
        var dates = new List<DateTimeOffset>();

        if (string.IsNullOrEmpty(Dates)) return dates;

        // Format 2: "2025-11-15 to 2025-11-29"
        if (Dates.Contains(" to "))
        {
            var parts = Dates.Split(" to ");
            if (parts.Length == 2)
            {
                if (DateTime.TryParseExact(parts[0].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var start) &&
                    DateTime.TryParseExact(parts[1].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var end))
                {
                    dates.Add(new DateTimeOffset(start, TimeSpan.FromHours(2)));
                    dates.Add(new DateTimeOffset(end, TimeSpan.FromHours(2)));
                }
            }
        }
        // Format 3: "November 25, 2023 - Cape Town, December 2, 2023 - Johannesburg"
        else if (Dates.Contains(" - "))
        {
            // Use regex to extract date patterns like "Month Day, Year - City"
            var pattern = @"([A-Za-z]+\s+\d{1,2},\s+\d{4})\s+-\s+[^,]+(?:,|$)";
            var matches = Regex.Matches(Dates, pattern);
            
            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1)
                {
                    var dateString = match.Groups[1].Value.Trim();
                    
                    // Try parsing formats like "November 25, 2023" or "December 2, 2023"
                    if (DateTime.TryParseExact(dateString, new[] { "MMMM dd, yyyy", "MMMM d, yyyy" }, 
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
                    {
                        dates.Add(new DateTimeOffset(parsed, TimeSpan.FromHours(2)));
                    }
                }
            }
        }

        return dates;
    }

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

