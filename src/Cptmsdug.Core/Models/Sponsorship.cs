using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Sponsorship
{
    [JsonPropertyName("types")]
    public List<string> Types { get; set; }

    [JsonPropertyName("contact")]
    public string Contact { get; set; }
}

