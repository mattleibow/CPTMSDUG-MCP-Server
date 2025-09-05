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
                Reviews = data.CommunityStats.Reviews,
                EventsHosted = data.CommunityStats.EventsHosted,
                YearsActive = data.Organization.YearsActive
            },
            SponsorshipTypes = data.Opportunities.Sponsorship.Types,
            SponsorshipBenefits = data.Opportunities.Speaking.Benefits,
            AudienceProfile = new
            {
                TechnologyFocus = data.Technologies.Primary,
                CommunityMission = data.Mission.Primary,
                ProfessionalLevel = "Mix of junior to senior developers and technical leaders",
                Industries = "Technology, consulting, healthcare, finance, and more"
            },
            ContactInformation = new
            {
                Email = data.Opportunities.Sponsorship.Contact,
                Process = "Contact us to discuss custom sponsorship packages"
            },
            Affiliations = data.Organization.Affiliations
        };
    }
}