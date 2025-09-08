using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class EventsTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get information about upcoming CPTMSDUG events. Perfect for answering 'What events are coming up?', 'When is the next meetup?', and 'How do I register for events?'")]
    public async Task<object> GetUpcomingEvents()
    {
        var data = await dataStore.GetDataAsync();
        var upcomingEvents = await dataStore.GetUpcomingEventsAsync();

        var upcomingEventsInfo = upcomingEvents.Select(evt => new
        {
            Name = evt.Name,
            StartDateTime = evt.StartDateTime,
            EndDateTime = evt.EndDateTime,
            Venue = evt.Venue,
            Status = evt.Status,
            MeetupUrl = evt.MeetupUrl,
            Topics = evt.Topics,
            Attendees = evt.Attendees,
            Type = evt.Type ?? "Regular Meetup",
            Description = !string.IsNullOrEmpty(evt.Abstract)
                ? TruncateText(evt.Abstract, 200)
                : "Details to be announced",
            Speakers = evt.AllSpeakers?.Select(s => new { s.Name, s.Company }).ToArray() ?? [],
            Agenda = evt.Agenda?.ToArray() ?? []
        }).ToList();

        return new
        {
            EventsOverview = new
            {
                TotalUpcoming = upcomingEvents.Count,
                EventFormat = data.Events.Format,
                TypicalVenues = data.Events.Format.Venues
            },
            UpcomingEvents = upcomingEventsInfo,
            HowToRegister = new
            {
                MeetupGroup = data.Contact.SocialMedia.Meetup,
                Instructions = "Events are free to attend. Register via our Meetup page."
            }
        };
    }

    [McpServerTool]
    [Description("Get detailed information about the next upcoming event. Use when someone asks 'What's the next event?' or wants specific details about the immediate next meetup.")]
    public async Task<object> GetNextEvent()
    {
        var upcomingEvents = await dataStore.GetUpcomingEventsAsync();
        var data = await dataStore.GetDataAsync();

        var nextEvent = upcomingEvents.FirstOrDefault();

        if (nextEvent == null)
        {
            return new
            {
                Message = "No upcoming events scheduled at the moment",
                StayUpdated = new
                {
                    MeetupGroup = data.Contact.SocialMedia.Meetup,
                    Discord = data.Contact.SocialMedia.Discord,
                    LinkedIn = data.Contact.SocialMedia.LinkedIn
                },
                TypicalSchedule = "Events are typically held monthly"
            };
        }

        return new
        {
            EventDetails = new
            {
                Name = nextEvent.Name,
                StartDateTime = nextEvent.StartDateTime,
                EndDateTime = nextEvent.EndDateTime,
                Venue = nextEvent.Venue,
                Status = nextEvent.Status,
                Type = nextEvent.Type ?? "Regular Meetup",
                Attendees = nextEvent.Attendees,
                Description = nextEvent.Abstract
            },
            Topics = nextEvent.Topics,
            Speakers = nextEvent.AllSpeakers?.Select(s => new { s.Name, s.Company }).ToArray() ?? [],
            Agenda = nextEvent.Agenda?.ToArray() ?? [],
            Registration = new
            {
                MeetupUrl = nextEvent.MeetupUrl,
                Status = nextEvent.Status,
                Cost = "Free"
            },
            WhyAttend = data.Mission.Values
        };
    }

    [McpServerTool]
    [Description("Get information about past CPTMSDUG events. Perfect for answering 'What events have you had?', 'Show me previous meetups', and 'What topics have been covered?'")]
    public async Task<object> GetPastEvents()
    {
        var data = await dataStore.GetDataAsync();
        var pastEvents = await dataStore.GetPastEventsAsync();

        var pastEventsInfo = pastEvents
            .Select(evt => new
            {
                Name = evt.Name,
                StartDateTime = evt.StartDateTime,
                EndDateTime = evt.EndDateTime,
                Venue = evt.Venue,
                MeetupUrl = evt.MeetupUrl,
                Topics = evt.Topics,
                Tags = evt.Tags,
                Attendees = evt.Attendees,
                Speakers = evt.AllSpeakers?.Select(s => new { s.Name, s.Company }).ToArray() ?? [],
                Description = !string.IsNullOrEmpty(evt.Abstract)
                    ? TruncateText(evt.Abstract, 200)
                    : "Event details",
                Sessions = evt.Sessions?.Select(s => new { Topic = s.Title, s.Speaker }).ToArray() ?? []
            })
            .OrderByDescending(evt => evt.StartDateTime)
            .ToList();

        return new
        {
            EventsOverview = new
            {
                TotalPastEvents = pastEventsInfo.Count,
                EventFormat = data.Events.Format,
                TotalAttendees = pastEvents.Sum(e => e.Attendees),
                AverageAttendance = pastEvents.Count > 0 ? pastEvents.Average(e => e.Attendees) : 0
            },
            PastEvents = pastEventsInfo,
            PopularTopics = GetPopularTopics(pastEvents),
            CommunityGrowth = new
            {
                TotalEventsHosted = data.CommunityStats.EventsHosted,
                CommunitySize = data.CommunityStats.Members
            }
        };
    }

    [McpServerTool]
    [Description("Get the most recent past events. Use when someone asks 'What was the last event?' or wants to see recent community activity.")]
    public async Task<object> GetRecentPastEvents(int count = 5)
    {
        var pastEvents = await dataStore.GetPastEventsAsync();
        var data = await dataStore.GetDataAsync();

        var recentEvents = pastEvents
            .OrderByDescending(evt => evt.StartDateTime)
            .Take(count)
            .Select(evt => new
            {
                Name = evt.Name,
                StartDateTime = evt.StartDateTime,
                EndDateTime = evt.EndDateTime,
                Venue = evt.Venue,
                Speakers = evt.AllSpeakers?.Select(s => new { s.Name, s.Company }).ToArray() ?? [],
                Topics = evt.Topics,
                Tags = evt.Tags,
                Attendees = evt.Attendees,
                MeetupUrl = evt.MeetupUrl,
                Description = !string.IsNullOrEmpty(evt.Abstract)
                    ? TruncateText(evt.Abstract, 150)
                    : "Event details",
                Sessions = evt.Sessions?.Select(s => new { Topic = s.Title, s.Speaker }).ToArray() ?? []
            })
            .ToList();

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
    public async Task<object> SearchEventsByTopic(string searchTerm)
    {
        var pastEvents = await dataStore.GetPastEventsAsync();
        var upcomingEvents = await dataStore.GetUpcomingEventsAsync();

        var matchingPastEvents = pastEvents
            .Where(evt =>
                (evt.Topics?.Any(topic => topic.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ?? false) ||
                (evt.Tags?.Any(tag => tag.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ?? false) ||
                evt.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                (evt.Abstract?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (evt.Sessions?.Any(session => session.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ?? false))
            .OrderByDescending(evt => evt.StartDateTime)
            .Select(evt => new
            {
                Name = evt.Name,
                StartDateTime = evt.StartDateTime,
                EndDateTime = evt.EndDateTime,
                Venue = evt.Venue,
                Speakers = evt.AllSpeakers?.Select(s => new { s.Name, s.Company }).ToArray() ?? [],
                Topics = evt.Topics,
                Tags = evt.Tags,
                Attendees = evt.Attendees,
                MeetupUrl = evt.MeetupUrl,
                Description = !string.IsNullOrEmpty(evt.Abstract)
                    ? TruncateText(evt.Abstract, 150)
                    : "Event details",
                RelevantSessions = evt.Sessions?
                    .Where(s => s.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .Select(s => new { Topic = s.Title, s.Speaker })
                    .ToArray() ?? []
            }).ToList();

        var matchingUpcomingEvents = upcomingEvents
            .Where(evt =>
                (evt.Topics?.Any(topic => topic.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ?? false) ||
                (evt.Tags?.Any(tag => tag.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ?? false) ||
                evt.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                (evt.Abstract?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (evt.Sessions?.Any(session => session.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ?? false))
            .OrderByDescending(evt => evt.StartDateTime)
            .Select(evt => new
            {
                Name = evt.Name,
                StartDateTime = evt.StartDateTime,
                EndDateTime = evt.EndDateTime,
                Venue = evt.Venue,
                Speakers = evt.AllSpeakers?.Select(s => new { s.Name, s.Company }).ToArray() ?? [],
                Topics = evt.Topics,
                Tags = evt.Tags,
                Attendees = evt.Attendees,
                MeetupUrl = evt.MeetupUrl,
                Description = !string.IsNullOrEmpty(evt.Abstract)
                    ? TruncateText(evt.Abstract, 150)
                    : "Event details",
                RelevantSessions = evt.Sessions?
                    .Where(s => s.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .Select(s => new { Topic = s.Title, s.Speaker })
                    .ToArray() ?? []
            }).ToList();

        return new
        {
            SearchTerm = searchTerm,
            PastEvents = new
            {
                Count = matchingPastEvents.Count,
                Events = matchingPastEvents
            },
            UpcomingEvents = new
            {
                Count = matchingUpcomingEvents.Count,
                Events = matchingUpcomingEvents
            },
            RelatedTopics = GetRelatedTopics(pastEvents, searchTerm)
        };
    }

    private static List<string> GetPopularTopics(List<Core.Models.Event> pastEvents)
    {
        return pastEvents
            .SelectMany(evt => (evt.Topics ?? []).Concat(evt.Tags ?? []))
            .Where(topic => !string.IsNullOrWhiteSpace(topic))
            .GroupBy(topic => topic, StringComparer.OrdinalIgnoreCase)
            .OrderByDescending(g => g.Count())
            .Take(10)
            .Select(g => g.Key)
            .ToList();
    }

    private static List<string> GetRelatedTopics(List<Core.Models.Event> pastEvents, string searchTerm)
    {
        var eventsWithSearchTerm = pastEvents.Where(evt =>
            (evt.Topics?.Any(topic => topic.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ?? false) ||
            (evt.Tags?.Any(tag => tag.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ?? false));

        return eventsWithSearchTerm
            .SelectMany(evt => (evt.Topics ?? []).Concat(evt.Tags ?? []))
            .Where(topic => !topic.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(topic))
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