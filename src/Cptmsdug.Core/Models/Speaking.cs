using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Speaking
{
    [JsonPropertyName("topics")]
    public List<string> Topics { get; set; }

    [JsonPropertyName("benefits")]
    public List<string> Benefits { get; set; }

    [JsonPropertyName("submission")]
    public string Submission { get; set; }
}

