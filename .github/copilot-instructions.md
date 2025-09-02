# CPTMSDUG MCP Server Development Instructions

**ALWAYS follow these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the information provided here.**

CPTMSDUG MCP Server is a .NET 8.0 C# library for loading and working with Cape Town MS Developer User Group data from https://cptmsdug.dev/mcp.json. It provides strongly typed models and async APIs for accessing community data.

## Working Effectively

### Bootstrap, Build, and Test the Repository

1. **Prerequisites**: .NET 8.0 SDK is required and available in this environment.

2. **Initial Setup** (run these commands in order):
   ```bash
   cd /home/runner/work/CPTMSDUG-MCP-Server/CPTMSDUG-MCP-Server
   dotnet restore
   dotnet build
   dotnet test
   ```

3. **Command Timing and Expectations**:
   - `dotnet restore` -- takes 1-18 seconds (1 second if already restored). NEVER CANCEL. Set timeout to 60+ seconds.
   - `dotnet build` -- takes 4-8 seconds. NEVER CANCEL. Set timeout to 60+ seconds.  
   - `dotnet test` -- takes 9-11 seconds. NEVER CANCEL. Set timeout to 60+ seconds.
   - All 15 tests should pass successfully (may show timeout messages but tests still pass).

4. **Code Formatting**:
   ```bash
   dotnet format --verify-no-changes  # Check formatting issues - takes 7-8 seconds
   dotnet format                      # Fix formatting issues - takes 7-8 seconds
   ```

### Key Project Structure

```
├── CPTMSDUG.MCP.sln                    # Solution file with 2 projects
├── CPTMSDUG.MCP.Core/                  # Main library project
│   ├── CPTMSDUG.MCP.Core.csproj       # Targets .NET 8.0
│   ├── Models/                        # 28 data model classes
│   │   ├── CptmsdugData.cs            # Root data model
│   │   ├── Organization.cs            # Organization info
│   │   ├── CommunityStats.cs          # Member/event statistics
│   │   ├── UpcomingEvent.cs           # Event information
│   │   ├── Speaker.cs                 # Speaker profiles
│   │   └── ...                        # Other models
│   └── Services/
│       └── CptmsdugDataStore.cs       # Main service with ICptmsdugDataStore interface
└── CPTMSDUG.MCP.Tests/                # XUnit test project
    ├── CPTMSDUG.MCP.Tests.csproj      # Test dependencies: XUnit, NJsonSchema
    ├── UnitTest1.cs                   # 11 comprehensive API tests
    └── SchemaValidationTests.cs       # 4 JSON schema validation tests
```

## Manual Validation Requirements

### Always Test Functionality After Changes

When making changes to the library, ALWAYS validate functionality by running this complete scenario:

1. **Create a test console application**:
   ```bash
   # Create temporary test app in /tmp to avoid committing it
   cd /tmp
   cat > Program.cs << 'EOF'
   using CPTMSDUG.MCP.Core.Services;
   
   class Program
   {
       static async Task Main(string[] args)
       {
           using var httpClient = new HttpClient();
           var dataStore = new CptmsdugDataStore(httpClient);
           
           // Test basic data loading
           var data = await dataStore.GetDataAsync();
           Console.WriteLine($"✓ Data loaded: {data.Name}");
           
           // Test organization info
           var org = await dataStore.GetOrganizationAsync();
           Console.WriteLine($"✓ Organization: {org.Name} in {org.Location.City}");
           
           // Test community stats
           var stats = await dataStore.GetCommunityStatsAsync();
           Console.WriteLine($"✓ Members: {stats.Members}, Rating: {stats.Rating}");
           
           // Test events and speakers
           var events = await dataStore.GetUpcomingEventsAsync();
           var speakers = await dataStore.GetSpeakersAsync();
           Console.WriteLine($"✓ Events: {events.Count}, Speakers: {speakers.Count}");
           
           Console.WriteLine("✅ All validation tests passed!");
       }
   }
   EOF
   
   cat > test-app.csproj << 'EOF'
   <Project Sdk="Microsoft.NET.Sdk">
     <PropertyGroup>
       <OutputType>Exe</OutputType>
       <TargetFramework>net8.0</TargetFramework>
       <ImplicitUsings>enable</ImplicitUsings>
     </PropertyGroup>
     <ItemGroup>
       <ProjectReference Include="/home/runner/work/CPTMSDUG-MCP-Server/CPTMSDUG-MCP-Server/CPTMSDUG.MCP.Core/CPTMSDUG.MCP.Core.csproj" />
     </ItemGroup>
   </Project>
   EOF
   
   # Run validation - takes 4 seconds
   dotnet run --project test-app.csproj
   ```

2. **Expected Output**:
   ```
   ✓ Data loaded: Cape Town MS Developer User Group
   ✓ Organization: Cape Town MS Developer User Group in Cape Town
   ✓ Members: 1877, Rating: 4.7
   ✓ Events: 5, Speakers: 18
   ✅ All validation tests passed!
   ```

3. **Clean up**:
   ```bash
   rm -f /tmp/Program.cs /tmp/test-app.csproj
   ```

## Build and Test Validation

### Pre-commit Checklist

Always run these commands before committing changes:

1. **Format code** (required - CI will fail if not formatted):
   ```bash
   dotnet format
   ```

2. **Build solution**:
   ```bash
   dotnet build
   ```

3. **Run all tests** (all 15 tests must pass):
   ```bash
   dotnet test
   ```

4. **Validate functionality** (run the manual validation scenario above)

### Understanding Test Failures

- Tests may show "Error loading CPTMSDUG data: A task was canceled." - this is normal timeout behavior during parallel test execution
- All 15 tests should still pass despite these timeout messages
- Tests validate live data from https://cptmsdug.dev/mcp.json so content may vary over time
- Core functionality tests are resilient to data changes

## Key Components and Locations

### Main Service Interface
**File**: `CPTMSDUG.MCP.Core/Services/CptmsdugDataStore.cs`
- `ICptmsdugDataStore` interface with 11 async methods
- `CptmsdugDataStore` implementation with background loading
- **Fast startup**: HTTP request starts immediately in constructor
- **Cached results**: First API call awaits, subsequent calls return immediately

### Core Models
**Directory**: `CPTMSDUG.MCP.Core/Models/`
- `CptmsdugData.cs` - Root data model
- `Organization.cs` - Organization details (name, location, affiliations)
- `CommunityStats.cs` - Metrics (members: 1877, events: 139+, rating: 4.7)
- `UpcomingEvent.cs` - Event with agenda and speakers
- `Speaker.cs` - Speaker profiles and statistics
- `Technologies.cs` - Primary/secondary tech focus areas
- `Contact.cs` - Email and social media contact info
- `Opportunities.cs` - Speaking, sponsorship, volunteering options

### Test Coverage
**Directory**: `CPTMSDUG.MCP.Tests/`
- `UnitTest1.cs` - 11 API functionality tests
- `SchemaValidationTests.cs` - 4 JSON schema validation tests
- Tests cover all major data access methods and schema compliance

## Dependencies and Requirements

### Runtime Dependencies
- **.NET 8.0** - Target framework
- **HttpClient** - Built-in, for API calls
- **System.Text.Json** - Built-in, for JSON parsing

### Development Dependencies  
- **XUnit** - Test framework
- **NJsonSchema** - Schema validation in tests
- **Microsoft.NET.Test.Sdk** - Test runner

### No External Dependencies
- No package manager commands beyond `dotnet restore`
- No build scripts or complex setup required
- No database or external services needed for development

## Common Development Tasks

### Adding New Data Models
1. Create model class in `CPTMSDUG.MCP.Core/Models/`
2. Add property to `CptmsdugData.cs` if root-level data
3. Add accessor method to `ICptmsdugDataStore` interface
4. Implement method in `CptmsdugDataStore` class
5. Add test in `UnitTest1.cs`
6. Run `dotnet test` to validate

### Modifying Existing API Methods
1. Update implementation in `CptmsdugDataStore.cs`
2. Update corresponding test in `UnitTest1.cs`
3. Run validation scenario to ensure functionality works
4. Verify all 15 tests still pass

### Updating JSON Schema Validation
1. Modify models in `CPTMSDUG.MCP.Core/Models/`
2. Run `SchemaValidationTests.cs` to regenerate schema
3. Check generated schema file in test output directory

## API Endpoint Information

### Data Source
- **URL**: https://cptmsdug.dev/mcp.json
- **Format**: JSON with community information
- **Update Frequency**: Updated regularly by CPTMSDUG organizers
- **Data Types**: Organization info, events, speakers, statistics, technologies

### Expected Data Volume
- **Members**: ~1,877 (growing)
- **Events**: 139+ hosted events
- **Speakers**: ~18 active speakers
- **Technologies**: 5 primary, 5 secondary focus areas
- **Upcoming Events**: Typically 3-7 events scheduled

## Error Handling

### Network Issues
- Library gracefully handles API failures
- Returns empty objects on errors rather than throwing
- Logs errors to console (in development)
- Tests may show timeout messages but should still pass

### Data Validation
- JSON parsing is case-insensitive
- Missing properties default to appropriate empty values
- Schema validation tests ensure data structure compliance

## Performance Characteristics

### Timing Expectations
- **Constructor**: Immediate return (starts background loading)
- **First API call**: ~4 seconds (awaits HTTP request)
- **Subsequent calls**: Immediate return (cached data)
- **Test execution**: 9-11 seconds for all 15 tests

### Memory Usage
- Minimal memory footprint
- Single cached copy of JSON data
- HttpClient properly disposed in tests

Remember: Always run the manual validation scenario after making changes to ensure the library works correctly with live data.