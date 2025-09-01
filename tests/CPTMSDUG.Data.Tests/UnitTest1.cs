using CPTMSDUG.Data.Services;

namespace CPTMSDUG.Data.Tests;

public class CptmsdugDataServiceTests
{
    private readonly string _testDataPath;

    public CptmsdugDataServiceTests()
    {
        // Get the path to the data file relative to the test project
        var currentDirectory = Directory.GetCurrentDirectory();
        var repositoryRoot = Path.GetFullPath(Path.Combine(currentDirectory, "..", "..", "..", "..", ".."));
        _testDataPath = Path.Combine(repositoryRoot, "data", "cptmsdug_data.json");
    }

    [Fact]
    public async Task LoadDataAsync_ShouldLoadDataSuccessfully()
    {
        // Arrange
        var service = new CptmsdugDataService();

        // Act
        var data = await service.LoadDataAsync(_testDataPath);

        // Assert
        Assert.NotNull(data);
        Assert.NotNull(data.UserGroup);
        Assert.Equal("Cape Town MS Developer User Group", data.UserGroup.Name);
        Assert.Equal("CPTMSDUG", data.UserGroup.Acronym);
    }

    [Fact]
    public async Task GetUserGroup_ShouldReturnUserGroupData()
    {
        // Arrange
        var service = new CptmsdugDataService();
        await service.LoadDataAsync(_testDataPath);

        // Act
        var userGroup = service.GetUserGroup();

        // Assert
        Assert.NotNull(userGroup);
        Assert.Equal("Cape Town MS Developer User Group", userGroup.Name);
        Assert.Equal("CPTMSDUG", userGroup.Acronym);
        Assert.Equal("https://cptmsdug.dev", userGroup.Website);
        Assert.Contains("@CPTMSDUG", userGroup.SocialLinks.Twitter);
    }

    [Fact]
    public async Task GetEvents_ShouldReturnEventsList()
    {
        // Arrange
        var service = new CptmsdugDataService();
        await service.LoadDataAsync(_testDataPath);

        // Act
        var events = service.GetEvents();

        // Assert
        Assert.NotNull(events);
        Assert.True(events.Count > 0);
        
        var firstEvent = events.First();
        Assert.NotNull(firstEvent.Title);
        Assert.NotNull(firstEvent.Description);
        Assert.NotNull(firstEvent.Date);
    }

    [Fact]
    public async Task GetSpeakers_ShouldReturnSpeakersList()
    {
        // Arrange
        var service = new CptmsdugDataService();
        await service.LoadDataAsync(_testDataPath);

        // Act
        var speakers = service.GetSpeakers();

        // Assert
        Assert.NotNull(speakers);
        Assert.True(speakers.Count > 0);
        
        var speaker = speakers.FirstOrDefault(s => s.Name == "Richard Campbell");
        Assert.NotNull(speaker);
        Assert.Contains(".NET Rocks", speaker.Bio);
    }

    [Fact]
    public async Task GetSummary_ShouldReturnSummaryData()
    {
        // Arrange
        var service = new CptmsdugDataService();
        await service.LoadDataAsync(_testDataPath);

        // Act
        var summary = service.GetSummary();

        // Assert
        Assert.NotNull(summary);
        Assert.True(summary.TotalEvents > 0);
        Assert.True(summary.TotalSpeakers > 0);
        Assert.True(summary.TotalConferences > 0);
    }

    [Fact]
    public void LoadDataAsync_WithInvalidPath_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var service = new CptmsdugDataService();
        var invalidPath = "nonexistent.json";

        // Act & Assert
        Assert.ThrowsAsync<FileNotFoundException>(() => service.LoadDataAsync(invalidPath));
    }
}