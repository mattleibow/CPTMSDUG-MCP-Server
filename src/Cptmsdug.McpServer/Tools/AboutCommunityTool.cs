using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class AboutCommunityTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get comprehensive information about what CPTMSDUG is, including its mission, values, technology focus, history, and community statistics. Perfect for answering 'What is CPTMSDUG?' and 'What does the community stand for?'")]
    public async Task<object> GetAboutCommunity()
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
                YearsActive = data.Organization.YearsActive
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
            Website = data.Website.Url
        };
    }

    [McpServerTool]
    [Description("Get detailed information about CPTMSDUG's mission, vision, and core values. Use this when someone asks specifically about the community's purpose or what drives the organization.")]
    public async Task<object> GetMissionAndValues()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            Mission = new
            {
                Primary = data.Mission.Primary,
                Secondary = data.Mission.Secondary
            },
            CoreValues = data.Mission.Values
        };
    }

    [McpServerTool]
    [Description("Get information about the technologies and platforms that CPTMSDUG focuses on. Useful when someone asks 'What technologies does CPTMSDUG cover?' or 'Is this community relevant for [specific technology]?'")]
    public async Task<object> GetTechnologyFocus()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            PrimaryTechnologies = data.Technologies.Primary,
            SecondaryTechnologies = data.Technologies.Secondary
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
                GeneralInquiries = data.Contact.SocialMedia
            }
        };
    }
}