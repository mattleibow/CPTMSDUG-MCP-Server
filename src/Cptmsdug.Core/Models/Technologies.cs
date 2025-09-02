using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Technologies
{
    [JsonPropertyName("primary")]
    public List<string> Primary { get; set; }

    [JsonPropertyName("secondary")]
    public List<string> Secondary { get; set; }
}

