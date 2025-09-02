using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class VolunteerTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get information about volunteering opportunities with CPTMSDUG. Perfect for answering 'How can I help organize events?', 'How can I volunteer?', and 'What volunteer roles are available?'")]
    public async Task<object> GetVolunteerOpportunities()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            VolunteerRoles = data.Opportunities.Volunteering.Roles,
            ContactInformation = new
            {
                Email = data.Opportunities.Volunteering.Contact,
                Purpose = "Express interest in volunteering and discuss available opportunities"
            },
            CommunityImpact = new
            {
                Members = data.CommunityStats.Members,
                EventsHosted = data.CommunityStats.EventsHosted,
                YearsActive = data.Organization.YearsActive,
                CommunityMission = data.Mission.Primary
            },
            ContactEmail = data.Opportunities.Volunteering.Contact
        };
    }

    [McpServerTool]
    [Description("Get specific information about event organization and planning volunteer roles. Use when someone wants to help with event logistics and planning.")]
    public async Task<object> GetEventOrganizationRoles()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            EventPlanningRoles = new
            {
                EventFrequency = data.Events.Format.Frequency,
                TypicalAttendance = data.Events.Format.Capacity,
                EventTypes = data.Events.Types
            },
            Contact = data.Opportunities.Volunteering.Contact
        };
    }

    [McpServerTool]
    [Description("Get information about content creation and community management volunteer opportunities. Perfect for those who want to help with online presence and communication.")]
    public async Task<object> GetContentAndCommunityRoles()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            CommunityChannels = new
            {
                Discord = data.Contact.SocialMedia.Discord,
                LinkedIn = data.Contact.SocialMedia.LinkedIn,
                Twitter = data.Contact.SocialMedia.Twitter,
                Meetup = data.Contact.SocialMedia.Meetup
            },
            Contact = data.Opportunities.Volunteering.Contact
        };
    }
}