using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class SpeakersTool(ICptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Gets information about all speakers who have presented at CPTMSDUG events, including their profiles and session details.")]
    public async Task<object> GetSpeakers()
    {
        var speakers = await dataStore.GetSpeakersAsync();
        return new
        {
            Speakers = speakers,
            SpeakerCount = speakers.Count
        };
    }

    [McpServerTool]
    [Description("Gets information about CPTMSDUG organizers and their roles in the community.")]
    public async Task<object> GetOrganizers()
    {
        var organizers = await dataStore.GetOrganizersAsync();
        return new
        {
            Organizers = organizers,
            OrganizerCount = organizers.Count
        };
    }

    [McpServerTool]
    [Description("Gets comprehensive information about both speakers and organizers in the CPTMSDUG community.")]
    public async Task<object> GetSpeakersAndOrganizers()
    {
        var speakers = await dataStore.GetSpeakersAsync();
        var organizers = await dataStore.GetOrganizersAsync();
        var speakerStats = await dataStore.GetSpeakerStatisticsAsync();
        
        return new
        {
            Speakers = speakers,
            Organizers = organizers,
            SpeakerStatistics = speakerStats,
            Summary = new
            {
                TotalSpeakers = speakers.Count,
                TotalOrganizers = organizers.Count
            }
        };
    }
}