using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class CptmsdugData
{
    [JsonPropertyName("user_group")]
    public UserGroup UserGroup { get; set; } = new();

    [JsonPropertyName("pages")]
    public Pages Pages { get; set; } = new();

    [JsonPropertyName("events")]
    public List<Event> Events { get; set; } = new();

    [JsonPropertyName("speakers")]
    public List<Speaker> Speakers { get; set; } = new();

    [JsonPropertyName("conferences")]
    public List<Conference> Conferences { get; set; } = new();

    [JsonPropertyName("dotnet_conf")]
    public DotNetConf DotNetConf { get; set; } = new();

    [JsonPropertyName("contact")]
    public Contact Contact { get; set; } = new();

    [JsonPropertyName("summary")]
    public Summary Summary { get; set; } = new();
}