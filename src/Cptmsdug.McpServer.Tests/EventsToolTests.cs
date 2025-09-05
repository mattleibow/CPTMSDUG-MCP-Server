namespace Cptmsdug.McpServer.Tests;

public class EventsToolTests : BaseMcpToolTest<EventsTool>
{
    protected override EventsTool CreateTool() => new EventsTool(DataStore);

    [Fact]
    public async Task GetUpcomingEvents_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetUpcomingEvents();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetNextEvent_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetNextEvent();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetPastEvents_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetPastEvents();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetRecentPastEvents_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetRecentPastEvents();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetRecentPastEvents_WithCount_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetRecentPastEvents(3);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task SearchEventsByTopic_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.SearchEventsByTopic("Azure");
        Assert.NotNull(result);
    }

}