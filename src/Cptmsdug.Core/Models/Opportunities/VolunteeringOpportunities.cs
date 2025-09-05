using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class VolunteeringOpportunities
{
    [JsonPropertyName("roles")]
    public List<string> Roles { get; set; }

    [JsonPropertyName("contact")]
    public string Contact { get; set; }
}

