using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class CommunityInfoTool(ICptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Gets comprehensive community information including statistics, organization details, and mission statement for the Cape Town Microsoft Developer User Group.")]
    public async Task<object> GetCommunityInfo()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            Organization = data.Organization,
            CommunityStats = data.CommunityStats,
            Mission = data.Mission,
            IsDataLoaded = await dataStore.IsDataLoadedAsync()
        };
    }

    [McpServerTool]
    [Description("Gets detailed statistics about the CPTMSDUG community including member count, events hosted, and community ratings.")]
    public async Task<object> GetCommunityStatistics()
    {
        var stats = await dataStore.GetCommunityStatsAsync();
        var speakerStats = await dataStore.GetSpeakerStatisticsAsync();

        return new
        {
            CommunityStats = stats,
            SpeakerStatistics = speakerStats
        };
    }

    [McpServerTool]
    [Description("Gets organization details including name, location, and affiliations for the Cape Town Microsoft Developer User Group.")]
    public async Task<object> GetOrganizationDetails()
    {
        var organization = await dataStore.GetOrganizationAsync();
        return organization;
    }

    [McpServerTool]
    [Description("Gets the mission statement and goals of the Cape Town Microsoft Developer User Group.")]
    public async Task<object> GetMissionStatement()
    {
        var mission = await dataStore.GetMissionAsync();
        return mission;
    }

    [McpServerTool]
    [Description("Gets comprehensive information about what the CPTMSDUG community is about, their core mission, values, goals, and what they care about as a developer community.")]
    public async Task<object> GetAboutCommunity()
    {
        var data = await dataStore.GetDataAsync();
        var technologies = await dataStore.GetTechnologiesAsync();
        var opportunities = await dataStore.GetOpportunitiesAsync();

        return new
        {
            Organization = data.Organization,
            Description = data.Description,
            Mission = data.Mission,
            Technologies = technologies,
            CommunityStats = data.CommunityStats,
            Opportunities = opportunities
        };
    }
}