using System.Text.Json.Serialization;
using Cptmsdug.Core.Models;

namespace Cptmsdug.Core.Models;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(CptmsdugData))]
[JsonSerializable(typeof(CommunityStats))]
[JsonSerializable(typeof(EventUpcoming))]
[JsonSerializable(typeof(EventPast))]
[JsonSerializable(typeof(EventSpeaker))]
[JsonSerializable(typeof(Organizer))]
[JsonSerializable(typeof(Organization))]
[JsonSerializable(typeof(Contact))]
[JsonSerializable(typeof(Technologies))]
[JsonSerializable(typeof(Mission))]
[JsonSerializable(typeof(Website))]
[JsonSerializable(typeof(Opportunities))]
[JsonSerializable(typeof(SpeakerStatistics))]
[JsonSerializable(typeof(List<EventUpcoming>))]
[JsonSerializable(typeof(List<EventPast>))]
[JsonSerializable(typeof(List<EventSpeaker>))]
[JsonSerializable(typeof(List<Organizer>))]
public partial class CptmsdugJsonContext : JsonSerializerContext
{
}