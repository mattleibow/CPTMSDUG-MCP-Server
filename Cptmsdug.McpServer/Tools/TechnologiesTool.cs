using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class TechnologiesTool(ICptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Gets information about the technologies and platforms that CPTMSDUG focuses on, including primary and secondary technology areas.")]
    public async Task<object> GetTechnologies()
    {
        var technologies = await dataStore.GetTechnologiesAsync();
        return technologies;
    }

    [McpServerTool]
    [Description("Gets technical details about the CPTMSDUG community's technology stack and focus areas.")]
    public async Task<object> GetTechnicalDetails()
    {
        var data = await dataStore.GetDataAsync();
        return new
        {
            Technologies = data.Technologies,
            TechnicalDetails = data.TechnicalDetails,
            Summary = new
            {
                PrimaryTechnologies = data.Technologies.Primary,
                SecondaryTechnologies = data.Technologies.Secondary,
                PrimaryCount = data.Technologies.Primary.Count,
                SecondaryCount = data.Technologies.Secondary.Count
            }
        };
    }
}