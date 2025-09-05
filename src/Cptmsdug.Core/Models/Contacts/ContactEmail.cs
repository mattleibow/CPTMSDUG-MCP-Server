using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class ContactEmail
{
    [JsonPropertyName("general")]
    public string General { get; set; }

    [JsonPropertyName("speakers")]
    public string Speakers { get; set; }

    [JsonPropertyName("sponsors")]
    public string Sponsors { get; set; }

    [JsonPropertyName("volunteers")]
    public string Volunteers { get; set; }
}

