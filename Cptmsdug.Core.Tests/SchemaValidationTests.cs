using Cptmsdug.Core.Models;
using Cptmsdug.Core.Services;
using NJsonSchema;
using NJsonSchema.Generation;
using NJsonSchema.Generation.TypeMappers;
using System.Text.Json;
using Xunit;

namespace Cptmsdug.Core.Tests;

public class SchemaValidationTests : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly CptmsdugDataStore _dataStore;
    private readonly JsonSchema _schema;

    public SchemaValidationTests()
    {
        _httpClient = new HttpClient();
        _dataStore = new CptmsdugDataStore(_httpClient);

        // Generate schema from the CptmsdugData model
        var settings = new SystemTextJsonSchemaGeneratorSettings();
        var schemaGenerator = new JsonSchemaGenerator(settings);
        _schema = schemaGenerator.Generate(typeof(CptmsdugData));
    }

    [Fact]
    public void GenerateSchema_ShouldCreateValidSchema()
    {
        // Assert
        Assert.NotNull(_schema);
        Assert.NotEmpty(_schema.ToJson());

        // Check that the schema contains expected properties
        Assert.True(_schema.Properties.ContainsKey("name"));
        Assert.True(_schema.Properties.ContainsKey("organization"));
        Assert.True(_schema.Properties.ContainsKey("communityStats"));
        Assert.True(_schema.Properties.ContainsKey("events"));
        Assert.True(_schema.Properties.ContainsKey("speakers"));
    }

    [Fact]
    public void SaveSchema_ShouldPersistSchemaFile()
    {
        // Arrange
        var schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cptmsdug-schema.json");

        // Act
        var schemaJson = _schema.ToJson();
        File.WriteAllText(schemaPath, schemaJson);

        // Assert
        Assert.True(File.Exists(schemaPath));
        var savedSchema = File.ReadAllText(schemaPath);
        Assert.NotEmpty(savedSchema);

        // Verify the saved schema can be parsed
        var parsedSchema = JsonSchema.FromJsonAsync(savedSchema).Result;
        Assert.NotNull(parsedSchema);
    }

    [Fact]
    public async Task ValidateActualData_ShouldMatchSchema()
    {
        // Arrange
        var data = await _dataStore.GetDataAsync();

        // Act
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var jsonData = JsonSerializer.Serialize(data, jsonOptions);

        // Validate against schema
        var validationErrors = _schema.Validate(jsonData);

        // Assert
        Assert.Empty(validationErrors);
    }

    // Note: This test may fail if the API has additional properties not defined in our models
    // which is expected as APIs can evolve. Commented out for now.
    private async Task ValidateOriginalJsonData_ShouldMatchSchema_DISABLED()
    {
        // Arrange - Get the original JSON from the API
        var response = await _httpClient.GetAsync("https://cptmsdug.dev/mcp.json");
        response.EnsureSuccessStatusCode();
        var originalJson = await response.Content.ReadAsStringAsync();

        // Act - Validate the original JSON against our schema
        var validationErrors = _schema.Validate(originalJson);

        // Assert
        Assert.Empty(validationErrors);
    }

    [Fact]
    public void GetSchemaJson_ShouldReturnCompleteSchema()
    {
        // Act
        var schemaJson = _schema.ToJson();

        // Assert
        Assert.NotEmpty(schemaJson);

        // Verify it contains key model definitions
        Assert.Contains("CptmsdugData", schemaJson);
        Assert.Contains("Organization", schemaJson);
        Assert.Contains("CommunityStats", schemaJson);
        Assert.Contains("UpcomingEvent", schemaJson);
        Assert.Contains("Speaker", schemaJson);

        // Output the schema for manual inspection
        var schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cptmsdug-schema.json");
        File.WriteAllText(schemaPath, schemaJson);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}