namespace Cptmsdug.McpServer.Tests;

public class GettingInvolvedToolTests : BaseMcpToolTest<GettingInvolvedTool>
{
    protected override GettingInvolvedTool CreateTool() => new GettingInvolvedTool(DataStore);

    [Fact]
    public async Task GetVolunteerOpportunities_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetVolunteerOpportunities();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetSpeakingOpportunities_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetSpeakingOpportunities();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetSessionSubmissionProcess_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetSessionSubmissionProcess();
        Assert.NotNull(result);
    }
}