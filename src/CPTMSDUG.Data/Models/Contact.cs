using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class Contact
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("contact_details")]
    public List<string> ContactDetails { get; set; } = new();
}