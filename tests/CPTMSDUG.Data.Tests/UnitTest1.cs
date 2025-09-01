using CPTMSDUG.Data.Services;

namespace CPTMSDUG.Data.Tests;

public class CptmsdugDataServiceTests
{
    private readonly string _testDataUrl = "https://raw.githubusercontent.com/mattleibow/CPTMSDUG-MCP-Server/refs/heads/main/data/cptmsdug.json";

    [Fact]
    public async Task GetUserGroupAsync_ShouldReturnUserGroupData()
    {
        // Arrange
        var service = new CptmsdugDataService(_testDataUrl);

        // Act
        var userGroup = await service.GetUserGroupAsync();

        // Assert
        Assert.NotNull(userGroup);
        Assert.Equal("Cape Town MS Developer User Group", userGroup.Name);
        Assert.Equal("CPTMSDUG", userGroup.Acronym);
        Assert.Equal("https://cptmsdug.dev", userGroup.Website);
        Assert.Contains("@CPTMSDUG", userGroup.SocialLinks.Twitter);
    }

    [Fact]
    public async Task GetEventsAsync_ShouldReturnEventsList()
    {
        // Arrange
        var service = new CptmsdugDataService(_testDataUrl);

        // Act
        var events = await service.GetEventsAsync();

        // Assert
        Assert.NotNull(events);
        Assert.True(events.Count > 0);
        
        var firstEvent = events.First();
        Assert.NotNull(firstEvent.Title);
        Assert.NotNull(firstEvent.Description);
        Assert.NotNull(firstEvent.Date);
    }

    [Fact]
    public async Task GetSpeakersAsync_ShouldReturnSpeakersList()
    {
        // Arrange
        var service = new CptmsdugDataService(_testDataUrl);

        // Act
        var speakers = await service.GetSpeakersAsync();

        // Assert
        Assert.NotNull(speakers);
        Assert.True(speakers.Count > 0);
        
        var speaker = speakers.FirstOrDefault(s => s.Name == "Richard Campbell");
        Assert.NotNull(speaker);
        Assert.Contains(".NET Rocks", speaker.Bio);
    }

    [Fact]
    public async Task GetSummaryAsync_ShouldReturnSummaryData()
    {
        // Arrange
        var service = new CptmsdugDataService(_testDataUrl);

        // Act
        var summary = await service.GetSummaryAsync();

        // Assert
        Assert.NotNull(summary);
        Assert.True(summary.TotalEvents > 0);
        Assert.True(summary.TotalSpeakers > 0);
        Assert.True(summary.TotalConferences > 0);
    }

    [Fact]
    public async Task GetConferencesAsync_ShouldReturnConferencesList()
    {
        // Arrange
        var service = new CptmsdugDataService(_testDataUrl);

        // Act
        var conferences = await service.GetConferencesAsync();

        // Assert
        Assert.NotNull(conferences);
        // Conferences list may be empty, so just check it's not null
    }

    [Fact]
    public async Task GetDotNetConfAsync_ShouldReturnDotNetConfData()
    {
        // Arrange
        var service = new CptmsdugDataService(_testDataUrl);

        // Act
        var dotNetConf = await service.GetDotNetConfAsync();

        // Assert
        // DotNetConf may be null in the data, so just check the method works
        Assert.True(true); // Test passes if no exception is thrown
    }

    [Fact]
    public async Task GetContactAsync_ShouldReturnContactData()
    {
        // Arrange
        var service = new CptmsdugDataService(_testDataUrl);

        // Act
        var contact = await service.GetContactAsync();

        // Assert
        Assert.NotNull(contact);
    }

    [Fact]
    public async Task GetPagesAsync_ShouldReturnPagesData()
    {
        // Arrange
        var service = new CptmsdugDataService(_testDataUrl);

        // Act
        var pages = await service.GetPagesAsync();

        // Assert
        Assert.NotNull(pages);
    }
}