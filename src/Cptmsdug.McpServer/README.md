# CPTMSDUG MCP Server

A Model Context Protocol (MCP) server that provides AI assistants with access to Cape Town MS Developer User Group (CPTMSDUG) community data.

## Installation

Install as a VS Code MCP:

```json
{
  "servers": {
    "cptmsdug": {
      "type": "stdio",
      "command": "dnx",
      "args": [ "-y", "Cptmsdug.McpServer" ]
    }
  }
}
```

The server communicates via stdio using the Model Context Protocol and is designed to be used with MCP-compatible AI clients and assistants.

## What This Tool Provides

This MCP server gives AI assistants access to comprehensive CPTMSDUG community information through 25+ specialized tools covering:

- **Community Information**: Mission, values, organizers, and community stats
- **Events**: Upcoming meetups, event formats, registration details
- **Speaking Opportunities**: How to submit talks, topics, and speaker benefits  
- **Sponsorship**: Corporate partnership and venue hosting opportunities
- **Getting Involved**: Joining the community, contact information, guidelines
- **Networking**: Discord community, professional connections
- **Learning**: Skill development resources and certification support
- **Volunteering**: Ways to help organize and contribute to events
- **Event History**: Past speakers, event archives, and community statistics

## Example Questions AI Can Answer

With this MCP server, AI assistants can help with questions like:

- "What is CPTMSDUG and how can I get involved?"
- "When is the next CPTMSDUG event and how do I register?"
- "How can I speak at a CPTMSDUG meetup?"
- "What sponsorship opportunities are available?"
- "How do I connect with other developers in Cape Town?"
- "What topics are popular for CPTMSDUG presentations?"
- "Who are the organizers and how can I contact them?"

## Requirements

- .NET 10.0 runtime
- MCP-compatible AI client or assistant

## Data Source

All information is sourced live from the official CPTMSDUG API at https://cptmsdug.dev, ensuring up-to-date community information.

## More Information

- [Project Repository](https://github.com/mattleibow/CPTMSDUG-MCP-Server)
- [CPTMSDUG Website](https://cptmsdug.dev)
- [Model Context Protocol](https://modelcontextprotocol.io/)