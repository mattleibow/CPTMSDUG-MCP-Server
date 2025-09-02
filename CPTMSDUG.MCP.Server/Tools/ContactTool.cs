using ModelContextProtocol.Server;
using System.ComponentModel;
using CPTMSDUG.MCP.Core.Services;

namespace CPTMSDUG.MCP.Server.Tools;

[McpServerToolType]
public partial class ContactTool(ICptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Gets contact information for CPTMSDUG including email addresses, social media links, and website details.")]
    public async Task<object> GetContactInformation()
    {
        var contact = await dataStore.GetContactAsync();
        return contact;
    }

    [McpServerTool]
    [Description("Gets website information and structure for CPTMSDUG including main site and related web properties.")]
    public async Task<object> GetWebsiteInformation()
    {
        var website = await dataStore.GetWebsiteAsync();
        return website;
    }

    [McpServerTool]
    [Description("Gets comprehensive contact and website information for CPTMSDUG community engagement.")]
    public async Task<object> GetContactAndWebsiteInfo()
    {
        var contact = await dataStore.GetContactAsync();
        var website = await dataStore.GetWebsiteAsync();
        
        return new
        {
            Contact = contact,
            Website = website
        };
    }
}