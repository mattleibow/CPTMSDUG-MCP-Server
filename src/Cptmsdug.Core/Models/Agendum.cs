using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Agendum
{
    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("activity")]
    public string Activity { get; set; } = string.Empty;
}

