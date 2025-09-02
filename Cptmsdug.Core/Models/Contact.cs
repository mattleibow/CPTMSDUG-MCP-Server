using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Contact
{
    [JsonPropertyName("email")]
    public EmailContacts Email { get; set; } = new();

    [JsonPropertyName("socialMedia")]
    public SocialMedia SocialMedia { get; set; } = new();
}