using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class OpportunitiesTool(ICptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Gets information about all opportunities available with CPTMSDUG including speaking, sponsorship, and volunteering opportunities.")]
    public async Task<object> GetOpportunities()
    {
        var opportunities = await dataStore.GetOpportunitiesAsync();
        return opportunities;
    }

    [McpServerTool]
    [Description("Gets specific information about speaking opportunities at CPTMSDUG events, including how to submit proposals and speaker benefits.")]
    public async Task<object> GetSpeakingOpportunities()
    {
        var opportunities = await dataStore.GetOpportunitiesAsync();
        return new
        {
            SpeakingOpportunities = opportunities.Speaking
        };
    }

    [McpServerTool]
    [Description("Gets information about sponsorship opportunities for companies wanting to support CPTMSDUG events and community.")]
    public async Task<object> GetSponsorshipOpportunities()
    {
        var opportunities = await dataStore.GetOpportunitiesAsync();
        return new
        {
            SponsorshipOpportunities = opportunities.Sponsorship
        };
    }

    [McpServerTool]
    [Description("Gets information about volunteering opportunities for community members who want to help organize CPTMSDUG events.")]
    public async Task<object> GetVolunteeringOpportunities()
    {
        var opportunities = await dataStore.GetOpportunitiesAsync();
        return new
        {
            VolunteeringOpportunities = opportunities.Volunteering
        };
    }
}