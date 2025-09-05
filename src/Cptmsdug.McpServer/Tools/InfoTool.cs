using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class InfoTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get comprehensive information about what CPTMSDUG is, including its mission, values, technology focus, history, and community statistics. Perfect for answering 'What is CPTMSDUG?' and 'What does the community stand for?'")]
    public async Task<object> GetGeneralInfo()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            Identity = new
            {
                Name = data.Organization.Name,
                ShortName = data.Organization.ShortName,
                Description = data.Description,
                Type = data.Organization.Type,
                Location = $"{data.Organization.Location.City}, {data.Organization.Location.Country}",
                Founded = data.Organization.Founded,
                YearsActive = data.Organization.YearsActive,
                Website = data.Website.Url
            },
            Mission = new
            {
                Primary = data.Mission.Primary,
                Secondary = data.Mission.Secondary,
                CoreValues = data.Mission.Values
            },
            TechnologyFocus = new
            {
                PrimaryTechnologies = data.Technologies.Primary,
                SecondaryTechnologies = data.Technologies.Secondary
            },
            CommunityScale = new
            {
                Members = data.CommunityStats.Members,
                EventsHosted = data.CommunityStats.EventsHosted,
                Speakers = data.CommunityStats.Speakers,
                Rating = data.CommunityStats.Rating,
                Reviews = data.CommunityStats.Reviews
            },
            Affiliations = data.Organization.Affiliations,
            EventFormat = data.Events.Format
        };
    }

    [McpServerTool]
    [Description("Get information about the CPTMSDUG community organizers and leadership team. Perfect for answering 'Who runs CPTMSDUG?', 'Who are the organizers?', or 'How can I contact the leadership team?'")]
    public async Task<object> GetOrganizers()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            Organizers = data.Organizers.Select(organizer => new
            {
                Name = organizer.Name,
                Role = organizer.Role,
                Title = organizer.Title,
                Description = organizer.Description,
                Social = new
                {
                    Twitter = organizer.Social.Twitter,
                    LinkedIn = organizer.Social.LinkedIn
                }
            }).ToArray(),
            OrganizationContact = new
            {
                Email = data.Contact.Email,
                Website = data.Website.Url
            }
        };
    }

    [McpServerTool]
    [Description("Get information about social media channels, communications, and how to connect with the CPTMSDUG community. Perfect for answering 'How do I connect with other developers?', 'Are there chat channels?', 'How do I join Discord?', and 'Where can I network between events?'")]
    public async Task<object> GetSocialMediaAndCommunications()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            SocialMediaChannels = new
            {
                Discord = new
                {
                    Url = data.Contact.SocialMedia.Discord,
                    Purpose = "Online chat community for real-time discussions and networking"
                },
                LinkedIn = new
                {
                    Url = data.Contact.SocialMedia.LinkedIn,
                    Purpose = "Professional networking and updates"
                },
                Twitter = new
                {
                    Url = data.Contact.SocialMedia.Twitter,
                    Purpose = "Community updates and tech discussions"
                },
                Meetup = new
                {
                    Url = data.Contact.SocialMedia.Meetup,
                    Purpose = "Event registration and community meetups"
                },
                Sessionize = new
                {
                    Url = data.Contact.SocialMedia.Sessionize,
                    Purpose = "Speaker submissions and session management"
                }
            },
            EmailContacts = data.Contact.Email,
            Website = data.Website.Url,
            CommunityNetworkingInfo = new
            {
                Size = data.CommunityStats.Members,
                TechnologyFocus = data.Technologies.Primary,
                Values = data.Mission.Values,
                Rating = data.CommunityStats.Rating,
                SpeakerStatistics = data.SpeakerStatistics
            }
        };
    }
}