using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class CommunityConnectionsTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get information about connecting with other CPTMSDUG members and community channels. Perfect for answering 'How do I connect with other developers?', 'Are there chat channels?', and 'Where can I network between events?'")]
    public async Task<object> GetCommunityConnections()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            SocialMediaChannels = data.Contact.SocialMedia,
            EmailContacts = data.Contact.Email,
            CommunitySize = data.CommunityStats.Members,
            EventFormat = data.Events.Format,
            SpeakerStatistics = data.SpeakerStatistics,
            Website = data.Website.Url
        };
    }

    [McpServerTool]
    [Description("Get information about the Discord community and how to engage effectively. Use when someone wants to know about the online chat community specifically.")]
    public async Task<object> GetDiscordCommunityGuide()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            DiscordUrl = data.Contact.SocialMedia.Discord,
            CommunitySize = data.CommunityStats.Members,
            TechnologyFocus = data.Technologies.Primary,
            CommunityValues = data.Mission.Values
        };
    }

    [McpServerTool]
    [Description("Get information about networking opportunities and professional connections in the CPTMSDUG community. Perfect for career-focused networking questions.")]
    public async Task<object> GetProfessionalNetworking()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            SocialMediaChannels = data.Contact.SocialMedia,
            EventFormat = data.Events.Format,
            SpeakerStatistics = data.SpeakerStatistics,
            CommunityStats = data.CommunityStats,
            Organizers = data.Organizers.Select(o => new
            {
                o.Name,
                o.Role,
                o.Title
            })
        };
    }
}