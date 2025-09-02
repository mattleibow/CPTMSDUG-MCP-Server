using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class Contact
{
    [JsonPropertyName("email")]
    public EmailContacts Email { get; set; } = new();

    [JsonPropertyName("socialMedia")]
    public SocialMedia SocialMedia { get; set; } = new();
}