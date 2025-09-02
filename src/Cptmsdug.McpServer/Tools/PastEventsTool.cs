using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class PastEventsTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get information about past CPTMSDUG events. Perfect for answering 'What events have you had?', 'Show me previous meetups', and 'What topics have been covered?'")]
    public async Task<object> GetPastEvents()
    {
        var data = await dataStore.GetDataAsync();

        // Filter and curate the past events with essential information
        var pastEvents = data.Events.PastEvents.Select(evt => new
        {
            Name = evt.Name,
            Date = evt.Date,
            Venue = evt.Venue,
            MeetupUrl = evt.MeetupUrl,
            Topics = evt.Topics,
            Tags = evt.Tags,
            Attendees = evt.Attendees,
            Speaker = evt.Speaker,
            Description = !string.IsNullOrEmpty(evt.Abstract) ? TruncateText(evt.Abstract, 200) : "Event details",
            Sessions = evt.Sessions?.Select(s => new { Topic = s.Title, s.Speaker }).ToArray() ?? []
        }).OrderByDescending(evt => evt.Date).ToList();

        return new
        {
            EventsOverview = new
            {
                TotalPastEvents = pastEvents.Count,
                EventFormat = data.Events.Format
            },
            PastEvents = pastEvents,
            PopularTopics = GetPopularTopics(data.Events.PastEvents),
            CommunityGrowth = new
            {
                TotalAttendees = data.Events.PastEvents.Sum(e => e.Attendees),
                AverageAttendance = data.Events.PastEvents.Count > 0 ? data.Events.PastEvents.Average(e => e.Attendees) : 0
            }
        };
    }

    [McpServerTool]
    [Description("Get the most recent past events. Use when someone asks 'What was the last event?' or wants to see recent community activity.")]
    public async Task<object> GetRecentPastEvents(int count = 5)
    {
        var data = await dataStore.GetDataAsync();

        var recentEvents = data.Events.PastEvents
            .OrderByDescending(evt => evt.Date)
            .Take(count)
            .Select(evt => new
            {
                Name = evt.Name,
                Date = evt.Date,
                Venue = evt.Venue,
                Speaker = evt.Speaker,
                Topics = evt.Topics,
                Tags = evt.Tags,
                Attendees = evt.Attendees,
                MeetupUrl = evt.MeetupUrl,
                Description = !string.IsNullOrEmpty(evt.Abstract) ? TruncateText(evt.Abstract, 150) : "Event details",
                Sessions = evt.Sessions?.Select(s => new { Topic = s.Title, s.Speaker }).ToArray() ?? []
            }).ToList();

        return new
        {
            RecentEvents = recentEvents,
            CommunityStats = new
            {
                TotalMembersServed = data.CommunityStats.Members,
                EventsHosted = data.CommunityStats.EventsHosted,
                CommunityRating = data.CommunityStats.Rating
            }
        };
    }

    [McpServerTool]
    [Description("Search past events by topic or technology. Use when someone asks 'Have you had events about X?' or 'What Azure events have you had?'")]
    public async Task<object> SearchPastEventsByTopic(string searchTerm)
    {
        var data = await dataStore.GetDataAsync();

        var matchingEvents = data.Events.PastEvents
            .Where(evt =>
                evt.Topics.Any(topic => topic.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                evt.Tags.Any(tag => tag.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                evt.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                evt.Abstract.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                evt.Sessions.Any(session => session.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
            .OrderByDescending(evt => evt.Date)
            .Select(evt => new
            {
                Name = evt.Name,
                Date = evt.Date,
                Venue = evt.Venue,
                Speaker = evt.Speaker,
                Topics = evt.Topics,
                Tags = evt.Tags,
                Attendees = evt.Attendees,
                MeetupUrl = evt.MeetupUrl,
                Description = !string.IsNullOrEmpty(evt.Abstract) ? TruncateText(evt.Abstract, 150) : "Event details",
                RelevantSessions = evt.Sessions?.Where(s =>
                    s.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .Select(s => new { Topic = s.Title, s.Speaker }).ToArray() ?? []
            }).ToList();

        return new
        {
            SearchTerm = searchTerm,
            MatchingEventsCount = matchingEvents.Count,
            MatchingEvents = matchingEvents,
            RelatedTopics = GetRelatedTopics(data.Events.PastEvents, searchTerm),
            SuggestedUpcomingEvents = data.Events.UpcomingEvents
                .Where(evt => evt.Topics.Any(topic => topic.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                .Select(evt => new { evt.Name, evt.Date, evt.Topics })
                .ToList()
        };
    }

    private static List<string> GetPopularTopics(List<Core.Models.EventPast> pastEvents)
    {
        return pastEvents
            .SelectMany(evt => evt.Topics.Concat(evt.Tags))
            .GroupBy(topic => topic, StringComparer.OrdinalIgnoreCase)
            .OrderByDescending(g => g.Count())
            .Take(10)
            .Select(g => g.Key)
            .ToList();
    }

    private static List<string> GetRelatedTopics(List<Core.Models.EventPast> pastEvents, string searchTerm)
    {
        var eventsWithSearchTerm = pastEvents.Where(evt =>
            evt.Topics.Any(topic => topic.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
            evt.Tags.Any(tag => tag.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));

        return eventsWithSearchTerm
            .SelectMany(evt => evt.Topics.Concat(evt.Tags))
            .Where(topic => !topic.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .GroupBy(topic => topic, StringComparer.OrdinalIgnoreCase)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key)
            .ToList();
    }

    private static string TruncateText(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;

        return text.Substring(0, maxLength) + "...";
    }
}