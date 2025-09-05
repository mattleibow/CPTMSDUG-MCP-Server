namespace Cptmsdug.McpServer.Tests;

public class InfoToolTests : BaseMcpToolTest<InfoTool>
{
    protected override InfoTool CreateTool() => new InfoTool(DataStore);

    [Fact]
    public async Task GetGeneralInfo_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetGeneralInfo();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetOrganizers_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetOrganizers();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetSocialMediaAndCommunications_ShouldReturnValidResponse()
    {
        // Act & Assert - should not throw an exception
        var result = await Tool.GetSocialMediaAndCommunications();
        Assert.NotNull(result);
    }
}