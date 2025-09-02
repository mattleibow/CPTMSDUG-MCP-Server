using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class SponsorshipTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get information about sponsorship opportunities for companies wanting to support CPTMSDUG events and community. Perfect for answering 'How can my company sponsor?' and 'What sponsorship options are available?'")]
    public async Task<object> GetSponsorshipOpportunities()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            CommunityReach = new
            {
                Members = data.CommunityStats.Members,
                Rating = data.CommunityStats.Rating,
                Reviews = data.CommunityStats.Reviews
            },
            SponsorshipTypes = data.Opportunities.Sponsorship.Types,
            ContactInformation = new
            {
                Email = data.Opportunities.Sponsorship.Contact
            },
            CommunityValue = new
            {
                TechnologyFocus = data.Technologies.Primary,
                CommunityMission = data.Mission.Primary,
                YearsActive = data.Organization.YearsActive,
                Affiliations = data.Organization.Affiliations
            }
        };
    }

    [McpServerTool]
    [Description("Get specific information about sponsorship packages and corporate partnership options. Use when companies need detailed sponsorship information.")]
    public async Task<object> GetSponsorshipPackages()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            AvailableSponsorshipTypes = data.Opportunities.Sponsorship.Types,
            EventMetrics = new
            {
                CommunitySize = data.CommunityStats.Members,
                EventTypes = data.Events.Types,
                TypicalVenues = data.Events.Format.Venues
            },
            ContactEmail = data.Opportunities.Sponsorship.Contact
        };
    }

    [McpServerTool]
    [Description("Get information about hosting CPTMSDUG events at company venues. Perfect for companies asking 'Can we host an event at our office?'")]
    public async Task<object> GetVenueHostingOpportunities()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            TypicalEventFormat = new
            {
                Duration = data.Events.Format.Duration,
                Frequency = data.Events.Format.Frequency
            },
            Contact = new
            {
                Email = data.Opportunities.Sponsorship.Contact
            }
        };
    }
}