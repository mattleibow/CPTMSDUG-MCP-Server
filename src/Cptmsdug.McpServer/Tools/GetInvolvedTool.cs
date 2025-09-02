using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class GetInvolvedTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get information on how to join and get involved with CPTMSDUG. Perfect for answering 'How can I join?', 'How do I get involved?', 'Where do I sign up?', and 'How can I participate in the community?'")]
    public async Task<object> GetHowToJoin()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            SocialMediaChannels = data.Contact.SocialMedia,
            EmailContacts = data.Contact.Email,
            EventFormat = data.Events.Format,
            Website = data.Website.Url
        };
    }

    [McpServerTool]
    [Description("Get contact information and community channels for CPTMSDUG. Use when someone asks 'How do I contact CPTMSDUG?' or needs specific contact details.")]
    public async Task<object> GetContactInformation()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            EmailContacts = data.Contact.Email,
            SocialMediaChannels = data.Contact.SocialMedia,
            Website = data.Website.Url
        };
    }

    [McpServerTool]
    [Description("Get information about who can attend CPTMSDUG events and what to expect. Perfect for answering questions about experience levels, requirements, and event atmosphere.")]
    public async Task<object> GetWhoCanAttend()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            EventTypes = data.Events.Types,
            CommunityValues = data.Mission.Values,
            CommunityStats = data.CommunityStats,
            EventFormat = data.Events.Format
        };
    }
}