using System.Text.Json.Serialization;

namespace Cptmsdug.Core.Models;

public class CptmsdugMcpDataMeta
{
    [JsonPropertyName("lastUpdated")]
    public string LastUpdated { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("schemaVersion")]
    public string SchemaVersion { get; set; }

    [JsonPropertyName("dataSource")]
    public string DataSource { get; set; }

    [JsonPropertyName("maintainer")]
    public string Maintainer { get; set; }

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; }
}

