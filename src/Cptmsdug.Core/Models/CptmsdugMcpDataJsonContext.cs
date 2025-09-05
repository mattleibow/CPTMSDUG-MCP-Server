using System.Text.Json.Serialization;
using Cptmsdug.Core.Models;

namespace Cptmsdug.Core.Models;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(CommunityInformation))]
[JsonSerializable(typeof(CommunitySpeakerStatistics))]
[JsonSerializable(typeof(CommunityStats))]
[JsonSerializable(typeof(CommunityTechnologies))]
[JsonSerializable(typeof(Contact))]
[JsonSerializable(typeof(ContactEmail))]
[JsonSerializable(typeof(ContactSocialMedia))]
[JsonSerializable(typeof(CptmsdugMcpData))]
[JsonSerializable(typeof(CptmsdugMcpDataMeta))]
[JsonSerializable(typeof(Event))]
[JsonSerializable(typeof(EventAgendaItem))]
[JsonSerializable(typeof(EventFormat))]
[JsonSerializable(typeof(EventInformation))]
[JsonSerializable(typeof(EventSession))]
[JsonSerializable(typeof(EventStatistics))]
[JsonSerializable(typeof(List<Event>))]
[JsonSerializable(typeof(List<EventAgendaItem>))]
[JsonSerializable(typeof(List<EventSession>))]
[JsonSerializable(typeof(List<Organizer>))]
[JsonSerializable(typeof(List<Speaker>))]
[JsonSerializable(typeof(List<string>))]
[JsonSerializable(typeof(List<WebsitePage>))]
[JsonSerializable(typeof(Location))]
[JsonSerializable(typeof(Mission))]
[JsonSerializable(typeof(Opportunities))]
[JsonSerializable(typeof(Organizer))]
[JsonSerializable(typeof(OrganizerSocial))]
[JsonSerializable(typeof(SessionSubmissionInformation))]
[JsonSerializable(typeof(Speaker))]
[JsonSerializable(typeof(SpeakingOpportunities))]
[JsonSerializable(typeof(SponsorshipOpportunities))]
[JsonSerializable(typeof(VolunteeringOpportunities))]
[JsonSerializable(typeof(Website))]
[JsonSerializable(typeof(WebsitePage))]
[JsonSerializable(typeof(WebsiteStructure))]
[JsonSerializable(typeof(WebsiteTechnicalDetails))]
public partial class CptmsdugMcpDataJsonContext : JsonSerializerContext
{
}