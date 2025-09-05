using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Mission
{
    [JsonPropertyName("primary")]
    public string Primary { get; set; }

    [JsonPropertyName("secondary")]
    public string Secondary { get; set; }

    [JsonPropertyName("values")]
    public List<string> Values { get; set; }
}

