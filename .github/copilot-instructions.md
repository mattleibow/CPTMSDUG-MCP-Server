# CPTMSDUG MCP Server Development Guide

## Project Architecture

This is a .NET 10.0 solution with 3 projects that implements a Model Context Protocol (MCP) server for CPTMSDUG community data:

- **Cptmsdug.Core**: Data models and services for consuming CPTMSDUG API
- **Cptmsdug.Core.Tests**: XUnit tests for core functionality  
- **Cptmsdug.McpServer**: MCP server exposing AI tools via stdio transport

### Key Architecture Patterns

**Eager Data Loading**: `CptmsdugDataStore` starts HTTP requests in constructor via `_dataTask = LoadDataAsync()`, then all getters await this cached task. This enables fast startup while avoiding blocking the constructor.

**MCP Tool Pattern**: Tools are organized in separate files under `Tools/` folder. Each tool class:
- Decorated with `[McpServerToolType]` 
- Individual methods decorated with `[McpServerTool]` and `[Description]`
- Takes `CptmsdugDataStore` via constructor DI
- Returns anonymous objects optimized for AI consumption

Example tool structure:
```csharp
[McpServerToolType]
public partial class AboutCommunityTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get comprehensive information about CPTMSDUG...")]
    public async Task<object> GetAboutCommunity() => // anonymous object
}
```

## Development Workflows

### Building and Testing
```bash
# Build entire solution
dotnet build src/Cptmsdug.sln

# Run tests (note: tests hit live API at https://cptmsdug.dev/mcp.json)
dotnet test src/Cptmsdug.Core.Tests/

# Run MCP server 
cd src/Cptmsdug.McpServer && dotnet run
```

### Adding New MCP Tools
1. Create new file in `src/Cptmsdug.McpServer/Tools/`
2. Follow naming convention: `{Feature}Tool.cs` (e.g., `SpeakingGuideTool.cs`)
3. Use constructor DI for `CptmsdugDataStore`
4. Return structured anonymous objects, not raw data models
5. Include descriptive `[Description]` attributes for AI context

### JSON Deserialization Patterns
Models use `[JsonPropertyName]` attributes with camelCase API field names:
```csharp
[JsonPropertyName("communityStats")]
public CommunityStats CommunityStats { get; set; } = new();
```

Custom converters in `Converters/` handle polymorphic JSON (see `EventSessionConverter` for string/object handling).

## Project Conventions

**Nullable Reference Types**: Enabled across all projects. Initialize collections as `new()` in model properties.

**HttpClient Configuration**: Uses custom `HttpClientHandler` with disabled SSL validation for development:
```csharp
var handler = new HttpClientHandler {
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
};
```

**Test Patterns**: Tests hit live API and use realistic assertions (e.g., `> 1000 members`). Tests are resilient to changing data by checking structure/existence rather than exact values.

**Tool Response Structure**: Tools return nested anonymous objects that mirror the logical groupings needed by AI assistants, not the raw API structure.

## Critical Dependencies

- **ModelContextProtocol (0.3.0-preview.1)**: Core MCP functionality
- **Microsoft.Extensions.Hosting**: DI container and app lifecycle
- **System.Text.Json**: Built-in JSON handling with custom converters
- **XUnit**: Testing framework with live API integration

## Data Flow

1. `CptmsdugDataStore` constructor immediately starts fetching from `https://cptmsdug.dev/mcp.json`
2. MCP tools await the cached `_dataTask` for consistent, fast data access
3. Tools transform raw data into AI-friendly structured responses
4. MCP server exposes tools via stdio transport for AI client consumption

The entire system is designed for AI agents to quickly access and understand CPTMSDUG community information through well-structured, documented tools.