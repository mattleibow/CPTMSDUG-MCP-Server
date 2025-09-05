using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class Contact
{
    [JsonPropertyName("email")]
    public ContactEmail Email { get; set; }

    [JsonPropertyName("socialMedia")]
    public ContactSocialMedia SocialMedia { get; set; }
}

