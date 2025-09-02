using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class Contact
{
    [JsonPropertyName("email")]
    public EmailContacts Email { get; set; } = new();

    [JsonPropertyName("socialMedia")]
    public SocialMedia SocialMedia { get; set; } = new();
}

public class EmailContacts
{
    [JsonPropertyName("general")]
    public string General { get; set; } = string.Empty;

    [JsonPropertyName("speakers")]
    public string Speakers { get; set; } = string.Empty;

    [JsonPropertyName("sponsors")]
    public string Sponsors { get; set; } = string.Empty;

    [JsonPropertyName("volunteers")]
    public string Volunteers { get; set; } = string.Empty;
}

public class SocialMedia
{
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; } = string.Empty;

    [JsonPropertyName("linkedin")]
    public string LinkedIn { get; set; } = string.Empty;

    [JsonPropertyName("meetup")]
    public string Meetup { get; set; } = string.Empty;

    [JsonPropertyName("sessionize")]
    public string Sessionize { get; set; } = string.Empty;

    [JsonPropertyName("discord")]
    public string Discord { get; set; } = string.Empty;
}

public class Organizer
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("social")]
    public OrganizerSocial Social { get; set; } = new();
}

public class OrganizerSocial
{
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; } = string.Empty;

    [JsonPropertyName("linkedin")]
    public string LinkedIn { get; set; } = string.Empty;
}

public class Speaker
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("company")]
    public string Company { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("sessions")]
    public List<string> Sessions { get; set; } = new();

    [JsonPropertyName("specialties")]
    public List<string> Specialties { get; set; } = new();

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new();

    [JsonPropertyName("events")]
    public List<string> Events { get; set; } = new();
}