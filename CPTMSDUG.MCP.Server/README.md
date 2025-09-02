# CPTMSDUG MCP Server

A Model Context Protocol (MCP) server that provides tools for accessing Cape Town Microsoft Developer User Group (CPTMSDUG) data. This server exposes various tools that AI assistants can use to answer questions about the CPTMSDUG community.

## Features

The MCP server provides the following tools organized in separate files:

### CommunityInfoTool
- `GetCommunityInfo()` - Gets comprehensive community information including statistics, organization details, and mission
- `GetCommunityStatistics()` - Gets detailed community and speaker statistics  
- `GetOrganizationDetails()` - Gets organization details including name, location, and affiliations
- `GetMissionStatement()` - Gets the mission statement and goals

### EventsTool
- `GetUpcomingEvents()` - Gets information about upcoming CPTMSDUG events
- `GetAllEventInformation()` - Gets complete event information including formats and details

### SpeakersTool
- `GetSpeakers()` - Gets information about all speakers who have presented at events
- `GetOrganizers()` - Gets information about CPTMSDUG organizers
- `GetSpeakersAndOrganizers()` - Gets comprehensive information about both speakers and organizers

### TechnologiesTool
- `GetTechnologies()` - Gets information about technologies and platforms CPTMSDUG focuses on
- `GetTechnicalDetails()` - Gets technical details about the community's technology stack

### OpportunitiesTool
- `GetOpportunities()` - Gets all available opportunities (speaking, sponsorship, volunteering)
- `GetSpeakingOpportunities()` - Gets specific information about speaking opportunities
- `GetSponsorshipOpportunities()` - Gets information about sponsorship opportunities
- `GetVolunteeringOpportunities()` - Gets information about volunteering opportunities

### ContactTool
- `GetContactInformation()` - Gets contact information including email and social media
- `GetWebsiteInformation()` - Gets website information and structure
- `GetContactAndWebsiteInfo()` - Gets comprehensive contact and website information

## Usage

### Running the Server

```bash
dotnet run
```

The server uses stdio transport and will start listening for MCP protocol messages.

### Integration with MCP Clients

The server can be integrated with MCP-compatible clients. It exposes tools that provide raw data from the CPTMSDUG API, allowing AI assistants to answer questions about:

- Community statistics and membership
- Upcoming events and event formats
- Speaker profiles and organizer information
- Technology focus areas
- Speaking, sponsorship, and volunteering opportunities
- Contact information and community resources

### Data Source

All data is sourced from the live CPTMSDUG API at https://cptmsdug.dev/mcp.json using the `CPTMSDUG.MCP.Core` library.

## Dependencies

- .NET 8.0
- ModelContextProtocol (0.3.0-preview.1)
- Microsoft.Extensions.Hosting (9.0.6)
- Microsoft.Extensions.Http (9.0.6)
- CPTMSDUG.MCP.Core (project reference)

## Development

The tools are organized in the `Tools/` folder with each tool in a separate file for better navigation and maintainability. Each tool class is decorated with `[McpServerToolType]` and individual methods with `[McpServerTool]` to make them available to MCP clients.