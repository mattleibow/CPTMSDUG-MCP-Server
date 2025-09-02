using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class WebsiteStructure
{
    [JsonPropertyName("pages")]
    public List<WebPage> Pages { get; set; } = new();
}