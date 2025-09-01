using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class Speaker
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("bio")]
    public string Bio { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;

    [JsonPropertyName("image_alt")]
    public string ImageAlt { get; set; } = string.Empty;
}