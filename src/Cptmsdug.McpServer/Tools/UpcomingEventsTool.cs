using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class UpcomingEventsTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get information about upcoming CPTMSDUG events. Perfect for answering 'What events are coming up?', 'When is the next meetup?', and 'How do I register for events?'")]
    public async Task<object> GetUpcomingEvents()
    {
        var data = await dataStore.GetDataAsync();

        // Filter and curate the upcoming events with essential information
        var upcomingEvents = data.Events.UpcomingEvents.Select(evt => new
        {
            Name = evt.Name,
            Date = evt.Date,
            Time = evt.Time,
            Venue = evt.Venue,
            Status = evt.Status,
            MeetupUrl = evt.MeetupUrl,
            Topics = evt.Topics,
            Attendees = evt.Attendees,
            Type = evt.Type ?? "Regular Meetup",
            Description = !string.IsNullOrEmpty(evt.Abstract) ? TruncateText(evt.Abstract, 200) : "Details to be announced",
            Speakers = evt.Speakers?.Select(s => new { s.Name, s.Company }).ToArray() ?? []
        }).ToList();

        return new
        {
            EventsOverview = new
            {
                TotalUpcoming = upcomingEvents.Count,
                EventFormat = data.Events.Format
            },
            UpcomingEvents = upcomingEvents,
            TypicalVenues = data.Events.Format.Venues,
            HowToRegister = new
            {
                MeetupGroup = data.Contact.SocialMedia.Meetup
            }
        };
    }

    [McpServerTool]
    [Description("Get detailed information about the next upcoming event. Use when someone asks 'What's the next event?' or wants specific details about the immediate next meetup.")]
    public async Task<object> GetNextEvent()
    {
        var data = await dataStore.GetDataAsync();

        var nextEvent = data.Events.UpcomingEvents.FirstOrDefault();

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
                }
            };
        }

        return new
        {
            EventDetails = new
            {
                Name = nextEvent.Name,
                Date = nextEvent.Date,
                Time = nextEvent.Time,
                Venue = nextEvent.Venue,
                Status = nextEvent.Status,
                Type = nextEvent.Type ?? "Regular Meetup",
                Attendees = nextEvent.Attendees
            },
            Topics = nextEvent.Topics,
            Registration = new
            {
                MeetupUrl = nextEvent.MeetupUrl,
                Status = nextEvent.Status
            },
            Speakers = nextEvent.Speakers?.Select(s => new
            {
                s.Name,
                s.Company
            }).ToArray() ?? new object[0],
            Agenda = nextEvent.Agenda.ToArray(),
            WhyAttend = data.Mission.Values
        };
    }

    [McpServerTool]
    [Description("Get information about event format, what to expect, and how to prepare for CPTMSDUG events. Perfect for first-time attendees.")]
    public async Task<object> GetEventFormat()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            TypicalEventFormat = data.Events.Format,
            EventTypes = data.Events.Types,
            CommunityValues = data.Mission.Values
        };
    }

    private static string TruncateText(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;

        return text.Substring(0, maxLength) + "...";
    }
}