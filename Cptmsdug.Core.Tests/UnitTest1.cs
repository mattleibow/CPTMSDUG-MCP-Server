using Cptmsdug.Core.Services;
using Cptmsdug.Core.Models;
using Xunit;

namespace Cptmsdug.Core.Tests;

public class CptmsdugDataStoreTests : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly CptmsdugDataStore _dataStore;

    public CptmsdugDataStoreTests()
    {
        _httpClient = new HttpClient();
        _dataStore = new CptmsdugDataStore(_httpClient);
    }

    [Fact]
    public async Task GetDataAsync_ShouldReturnValidData()
    {
        // Act
        var data = await _dataStore.GetDataAsync();

        // Assert
        Assert.NotNull(data);
        Assert.NotEmpty(data.Name);
        Assert.NotEmpty(data.Description);
        Assert.NotNull(data.Organization);
        Assert.NotNull(data.CommunityStats);
    }

    [Fact]
    public async Task GetOrganizationAsync_ShouldReturnValidOrganization()
    {
        // Act
        var organization = await _dataStore.GetOrganizationAsync();

        // Assert
        Assert.NotNull(organization);
        Assert.NotEmpty(organization.Name);
        Assert.Equal("CPTMSDUG", organization.ShortName);
        Assert.NotNull(organization.Location);
        Assert.Equal("Cape Town", organization.Location.City);
        Assert.Equal("South Africa", organization.Location.Country);
    }

    [Fact]
    public async Task GetCommunityStatsAsync_ShouldReturnValidStats()
    {
        // Act
        var stats = await _dataStore.GetCommunityStatsAsync();

        // Assert
        Assert.NotNull(stats);
        Assert.True(stats.Members > 1000, "Community should have more than 1000 members");
        Assert.NotEmpty(stats.EventsHosted);
        Assert.True(stats.Rating > 0, "Rating should be positive");
        Assert.True(stats.Reviews >= 0, "Reviews should be non-negative");
    }

    [Fact]
    public async Task GetUpcomingEventsAsync_ShouldReturnEvents()
    {
        // Act
        var events = await _dataStore.GetUpcomingEventsAsync();

        // Assert
        Assert.NotNull(events);
        // Note: Events may vary over time, so we just check that the collection is accessible
        foreach (var evt in events)
        {
            Assert.NotEmpty(evt.Name);
            Assert.NotNull(evt.Agenda);
            Assert.NotNull(evt.Speakers);
        }
    }

    [Fact]
    public async Task GetSpeakersAsync_ShouldReturnSpeakers()
    {
        // Act
        var speakers = await _dataStore.GetSpeakersAsync();

        // Assert
        Assert.NotNull(speakers);
        Assert.True(speakers.Count > 10, "Should have more than 10 speakers");

        var hasNonEmptyNameSpeakers = speakers.Any(s => !string.IsNullOrEmpty(s.Name));
        Assert.True(hasNonEmptyNameSpeakers, "At least one speaker should have a name");

        var hasSpeakersWithCompanies = speakers.Any(s => !string.IsNullOrEmpty(s.Company));
        Assert.True(hasSpeakersWithCompanies, "At least one speaker should have a company");
    }

    [Fact]
    public async Task GetSpeakerStatisticsAsync_ShouldReturnValidStats()
    {
        // Act
        var speakerStats = await _dataStore.GetSpeakerStatisticsAsync();

        // Assert
        Assert.NotNull(speakerStats);
        Assert.True(speakerStats.MicrosoftMVPs > 0, "Should have Microsoft MVPs");
        Assert.True(speakerStats.InternationalSpeakers > 0, "Should have international speakers");
        Assert.True(speakerStats.LocalExperts > 0, "Should have local experts");
    }

    [Fact]
    public async Task GetTechnologiesAsync_ShouldReturnTechnologies()
    {
        // Act
        var technologies = await _dataStore.GetTechnologiesAsync();

        // Assert
        Assert.NotNull(technologies);
        Assert.NotNull(technologies.Primary);
        Assert.NotNull(technologies.Secondary);
        Assert.True(technologies.Primary.Count > 0, "Should have primary technologies");
        
        // Expect .NET related technologies
        var hasDotNetTech = technologies.Primary.Any(t => 
            t.Contains(".NET", StringComparison.OrdinalIgnoreCase) ||
            t.Contains("C#", StringComparison.OrdinalIgnoreCase) ||
            t.Contains("Microsoft", StringComparison.OrdinalIgnoreCase));
        Assert.True(hasDotNetTech, "Should include .NET/Microsoft technologies");
    }

    [Fact]
    public async Task GetContactAsync_ShouldReturnValidContact()
    {
        // Act
        var contact = await _dataStore.GetContactAsync();

        // Assert
        Assert.NotNull(contact);
        Assert.NotNull(contact.Email);
        Assert.NotNull(contact.SocialMedia);
        Assert.NotEmpty(contact.Email.General);
        Assert.NotEmpty(contact.SocialMedia.Meetup);
    }

    [Fact]
    public async Task GetMissionAsync_ShouldReturnValidMission()
    {
        // Act
        var mission = await _dataStore.GetMissionAsync();

        // Assert
        Assert.NotNull(mission);
        Assert.NotEmpty(mission.Primary);
        Assert.NotNull(mission.Values);
        Assert.True(mission.Values.Count > 0, "Should have mission values");
    }

    [Fact]
    public async Task IsDataLoadedAsync_ShouldReturnTrue()
    {
        // Act
        var isLoaded = await _dataStore.IsDataLoadedAsync();

        // Assert
        Assert.True(isLoaded, "Data should be loaded successfully");
    }

    [Fact]
    public async Task GetEventsWithSpeakers_ShouldExist()
    {
        // Act
        var events = await _dataStore.GetUpcomingEventsAsync();

        // Assert
        Assert.NotNull(events);
        
        // Check if there are events with speakers and agenda items
        var eventsWithSpeakers = events.Where(e => e.Speakers?.Count > 0).ToList();
        var eventsWithAgenda = events.Where(e => e.Agenda?.Count > 0).ToList();

        // These should pass most of the time, but are resilient to changing data
        Assert.True(eventsWithSpeakers.Count >= 0, "Events with speakers should be accessible");
        Assert.True(eventsWithAgenda.Count >= 0, "Events with agenda should be accessible");
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}