using System.Text.Json.Serialization;

namespace CPTMSDUG.Data.Models;

public class Metadata
{
    [JsonPropertyName("extraction_info")]
    public ExtractionInfo? ExtractionInfo { get; set; }
    
    [JsonPropertyName("data_structure")]
    public DataStructure? DataStructure { get; set; }
    
    [JsonPropertyName("common_questions")]
    public CommonQuestion[] CommonQuestions { get; set; } = Array.Empty<CommonQuestion>();
    
    [JsonPropertyName("update_recommendations")]
    public UpdateRecommendations? UpdateRecommendations { get; set; }
}

public class ExtractionInfo
{
    [JsonPropertyName("extracted_at")]
    public string ExtractedAt { get; set; } = string.Empty;
    
    [JsonPropertyName("source_website")]
    public string SourceWebsite { get; set; } = string.Empty;
    
    [JsonPropertyName("extracted_pages")]
    public string[] ExtractedPages { get; set; } = Array.Empty<string>();
    
    [JsonPropertyName("extraction_method")]
    public string ExtractionMethod { get; set; } = string.Empty;
}

public class DataStructure
{
    [JsonPropertyName("general.json")]
    public DataFileInfo? General { get; set; }
    
    [JsonPropertyName("events.json")]
    public DataFileInfo? Events { get; set; }
    
    [JsonPropertyName("speakers.json")]
    public DataFileInfo? Speakers { get; set; }
    
    [JsonPropertyName("conferences.json")]
    public DataFileInfo? Conferences { get; set; }
}

public class DataFileInfo
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("key_fields")]
    public string[] KeyFields { get; set; } = Array.Empty<string>();
    
    [JsonPropertyName("event_types")]
    public string[]? EventTypes { get; set; }
}

public class CommonQuestion
{
    [JsonPropertyName("question")]
    public string Question { get; set; } = string.Empty;
    
    [JsonPropertyName("data_source")]
    public string DataSource { get; set; } = string.Empty;
    
    [JsonPropertyName("field")]
    public string? Field { get; set; }
    
    [JsonPropertyName("fields")]
    public string[]? Fields { get; set; }
    
    [JsonPropertyName("approach")]
    public string? Approach { get; set; }
}

public class UpdateRecommendations
{
    [JsonPropertyName("frequency")]
    public string Frequency { get; set; } = string.Empty;
    
    [JsonPropertyName("reason")]
    public string Reason { get; set; } = string.Empty;
    
    [JsonPropertyName("priority_pages")]
    public string[] PriorityPages { get; set; } = Array.Empty<string>();
}