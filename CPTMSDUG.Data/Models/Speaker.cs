using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class Speaker
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("expertise")]
    public string[] Expertise { get; set; } = Array.Empty<string>();
    
    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;
}