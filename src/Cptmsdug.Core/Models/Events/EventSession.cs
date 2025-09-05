using System.Text.Json.Serialization;
using Cptmsdug.Core.Converters;

namespace Cptmsdug.Core.Models;

[JsonConverter(typeof(EventSessionConverter))]
public class EventSession
{
    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("speaker")]
    public string Speaker { get; set; } = string.Empty;

    [JsonPropertyName("abstract")]
    public string Abstract { get; set; } = string.Empty;

    [JsonPropertyName("learningOutcomes")]
    public List<string> LearningOutcomes { get; set; } = new();

    [JsonPropertyName("funFact")]
    public string FunFact { get; set; } = string.Empty;

    [JsonPropertyName("note")]
    public string Note { get; set; } = string.Empty;
}

