namespace Cptmsdug.McpServer.Tests;

public class SponsorshipToolTests : BaseMcpToolTest<SponsorshipTool>
{
    protected override SponsorshipTool CreateTool() => new SponsorshipTool(DataStore);

    [Fact]
    public async Task GetSponsorshipOpportunities_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetSponsorshipOpportunities();
        Assert.NotNull(result);
    }
}