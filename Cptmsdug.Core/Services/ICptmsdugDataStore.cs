using Cptmsdug.Core.Models;

namespace Cptmsdug.Core.Services;

public interface ICptmsdugDataStore
{
    Task<CptmsdugData> GetDataAsync();
    Task<CommunityStats> GetCommunityStatsAsync();
    Task<List<UpcomingEvent>> GetUpcomingEventsAsync();
    Task<List<Speaker>> GetSpeakersAsync();
    Task<List<Organizer>> GetOrganizersAsync();
    Task<Organization> GetOrganizationAsync();
    Task<Contact> GetContactAsync();
    Task<Technologies> GetTechnologiesAsync();
    Task<Mission> GetMissionAsync();
    Task<Website> GetWebsiteAsync();
    Task<Opportunities> GetOpportunitiesAsync();
    Task<SpeakerStatistics> GetSpeakerStatisticsAsync();
    Task<bool> IsDataLoadedAsync();
}
