using Cptmsdug.Core.Services;

namespace Cptmsdug.Core.Tests;

public class EventAllSpeakersIntegrationTests : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly CptmsdugDataStore _dataStore;

    public EventAllSpeakersIntegrationTests()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        _httpClient = new HttpClient(handler);
        _dataStore = new CptmsdugDataStore(_httpClient);
    }

    [Fact]
    public async Task AllSpeakers_WithRealData_CollectsAllSpeakerSources()
    {
        // Arrange
        var data = await _dataStore.GetDataAsync();
        
        // Act - Find events with different speaker patterns
        var vsCodeDevDaysEvent = data.Events.AllEvents.FirstOrDefault(e => e.Name.Contains("VS Code Dev Days"));
        var ragWordpressEvent = data.Events.AllEvents.FirstOrDefault(e => e.Name.Contains("RAG + Building a WordPress Site"));
        var richardCampbellEvent = data.Events.AllEvents.FirstOrDefault(e => e.Name.Contains("Special Event with Richard Campbell"));
        
        // Assert VS Code Dev Days (has detailed speakers)
        if (vsCodeDevDaysEvent != null)
        {
            var allSpeakers = vsCodeDevDaysEvent.AllSpeakers;
            Assert.True(allSpeakers.Count >= 4);
            Assert.Contains(allSpeakers, s => s.Name == "Nicolas Blank");
            Assert.Contains(allSpeakers, s => s.Name == "Matthew Leibowitz");
            
            // Verify detailed information is preserved
            var mattSpeaker = allSpeakers.FirstOrDefault(s => s.Name == "Matthew Leibowitz");
            Assert.NotNull(mattSpeaker);
            Assert.Equal("Microsoft", mattSpeaker.Company);
            Assert.Equal("Principal Software Engineer at Microsoft", mattSpeaker.Title);
        }
        
        // Assert RAG + WordPress event (has session speakers)
        if (ragWordpressEvent != null)
        {
            var allSpeakers = ragWordpressEvent.AllSpeakers;
            Assert.True(allSpeakers.Count >= 2);
            Assert.Contains(allSpeakers, s => s.Name.Contains("Abed Matini"));
            Assert.Contains(allSpeakers, s => s.Name.Contains("Louise van der Bijl"));
        }
        
        // Assert Richard Campbell event (has direct speaker)
        if (richardCampbellEvent != null)
        {
            var allSpeakers = richardCampbellEvent.AllSpeakers;
            Assert.Single(allSpeakers);
            Assert.Contains(allSpeakers, s => s.Name.Contains("Richard Campbell"));
        }
    }

    [Fact]
    public async Task AllSpeakers_ComparedToIndividualSources_ProducesExpectedResults()
    {
        // Arrange
        var data = await _dataStore.GetDataAsync();
        
        // Act - Test all events
        foreach (var evt in data.Events.AllEvents)
        {
            var allSpeakers = evt.AllSpeakers;
            
            // Count expected speakers from individual sources
            var expectedCount = 0;
            
            // Count detailed speakers
            if (evt.Speakers?.Count > 0)
            {
                expectedCount += evt.Speakers.Count;
            }
            
            // Count session speakers (that aren't already in detailed speakers)
            if (evt.Sessions?.Count > 0)
            {
                var sessionSpeakerNames = evt.Sessions
                    .Where(s => !string.IsNullOrEmpty(s.Speaker))
                    .Select(s => s.Speaker)
                    .Where(name => evt.Speakers?.Any(ds => string.Equals(ds.Name, name, StringComparison.OrdinalIgnoreCase)) != true)
                    .Distinct()
                    .Count();
                expectedCount += sessionSpeakerNames;
            }
            
            // Count direct speaker (if not already in other sources)
            if (!string.IsNullOrEmpty(evt.Speaker))
            {
                var hasDirectSpeaker = evt.Speakers?.Any(ds => string.Equals(ds.Name, evt.Speaker, StringComparison.OrdinalIgnoreCase)) != true &&
                                      evt.Sessions?.Any(s => string.Equals(s.Speaker, evt.Speaker, StringComparison.OrdinalIgnoreCase)) != true;
                if (hasDirectSpeaker)
                {
                    expectedCount++;
                }
            }
            
            // Assert that AllSpeakers includes all expected speakers
            Assert.True(allSpeakers.Count >= expectedCount, 
                $"Event '{evt.Name}' should have at least {expectedCount} speakers, but AllSpeakers returned {allSpeakers.Count}");
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}