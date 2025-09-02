using System.Text.Json.Serialization;

namespace CPTMSDUG.MCP.Core.Models;

public class Meta
{
    [JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public string Version { get; set; } = string.Empty;

    [JsonPropertyName("schemaVersion")]
    public string SchemaVersion { get; set; } = string.Empty;

    [JsonPropertyName("dataSource")]
    public string DataSource { get; set; } = string.Empty;

    [JsonPropertyName("maintainer")]
    public string Maintainer { get; set; } = string.Empty;

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; } = string.Empty;
}