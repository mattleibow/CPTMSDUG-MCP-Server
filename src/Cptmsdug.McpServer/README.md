# CPTMSDUG MCP Server

A Model Context Protocol (MCP) server that provides AI assistants with tools to access Cape Town Microsoft Developer User Group (CPTMSDUG) data.

## Quick Start

### Running the Server
```bash
dotnet run
```

The server uses stdio transport and communicates via the Model Context Protocol.

### Integration
The server can be integrated with any MCP-compatible client to provide AI assistants with access to CPTMSDUG community information.

## Available Tools

The MCP server provides 25+ tools organized across 8 categories:

- **About Community**: Mission, values, technology focus, organizers
- **Events**: Upcoming events, event formats, next meetup details  
- **Speaking**: Submission process, topics, speaker benefits
- **Sponsorship**: Corporate partnerships and venue hosting
- **Getting Involved**: How to join, contact info, attendance guidelines
- **Community Connections**: Networking, Discord, professional connections
- **Learning & Development**: Skill development, certification support
- **Volunteering**: How to help organize and contribute
- **Past Events**: Event history, speaker archives, statistics

For complete details, see the [Tools Reference](../../docs/tools.md).

## Common Use Cases

This server enables AI assistants to answer questions like:
- "What is CPTMSDUG and how can I get involved?"
- "When is the next event and how do I register?"
- "How can I speak at a CPTMSDUG event?"
- "What sponsorship opportunities are available?"
- "How do I connect with other developers in the community?"

See the full list of [questions this server can answer](../../docs/questions.md).

## Data Source

All data is sourced from the live CPTMSDUG API at https://cptmsdug.dev/mcp.json using the `Cptmsdug.Core` library.

## Dependencies

- .NET 10.0
- ModelContextProtocol (0.3.0-preview.1)
- Microsoft.Extensions.Hosting (9.0.6)
- Microsoft.Extensions.Http (9.0.6)
- Cptmsdug.Core (project reference)