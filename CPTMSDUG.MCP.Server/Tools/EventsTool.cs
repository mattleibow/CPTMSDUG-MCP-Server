using ModelContextProtocol.Server;
using System.ComponentModel;
using CPTMSDUG.MCP.Core.Services;

namespace CPTMSDUG.MCP.Server.Tools;

[McpServerToolType]
public partial class EventsTool(ICptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Gets information about upcoming CPTMSDUG events including dates, topics, speakers, and agendas.")]
    public async Task<object> GetUpcomingEvents()
    {
        var events = await dataStore.GetUpcomingEventsAsync();
        return new
        {
            UpcomingEvents = events,
            EventCount = events.Count
        };
    }

    [McpServerTool]
    [Description("Gets complete event information including both upcoming events and event format details.")]
    public async Task<object> GetAllEventInformation()
    {
        var data = await dataStore.GetDataAsync();
        return new
        {
            Events = data.Events,
            EventSummary = new
            {
                UpcomingCount = data.Events.UpcomingEvents.Count,
                HasUpcomingEvents = data.Events.UpcomingEvents.Any()
            }
        };
    }
}