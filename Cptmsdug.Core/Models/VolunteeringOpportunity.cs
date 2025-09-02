using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class VolunteeringOpportunity
{
    [JsonPropertyName("roles")]
    public List<string> Roles { get; set; } = new();

    [JsonPropertyName("contact")]
    public string Contact { get; set; } = string.Empty;
}