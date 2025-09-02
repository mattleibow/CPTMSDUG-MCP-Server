# CPTMSDUG MCP Server

A C# library and Model Context Protocol (MCP) server for accessing Cape Town Microsoft Developer User Group (CPTMSDUG) data. This project provides both a .NET library for developers and an MCP server that enables AI assistants to answer questions about the CPTMSDUG community.

## What's Included

- **Cptmsdug.Core**: .NET library for loading CPTMSDUG data from https://cptmsdug.dev/mcp.json
- **Cptmsdug.McpServer**: MCP server providing AI tools for community information
- **Comprehensive Documentation**: Detailed guides for tools and common use cases

## Quick Start

### Prerequisites
- .NET 10.0 SDK

### Building the Project
```bash
git clone https://github.com/mattleibow/CPTMSDUG-MCP-Server.git
cd CPTMSDUG-MCP-Server
dotnet build
```

### Running Tests
```bash
dotnet test
```

### Running the MCP Server
```bash
cd src/Cptmsdug.McpServer
dotnet run
```

## Documentation

- [MCP Tools Reference](docs/tools.md) - Complete list of available tools and data sources
- [Common Questions](docs/questions.md) - Questions this server can help answer about CPTMSDUG
- [MCP Server Details](src/Cptmsdug.McpServer/README.md) - Technical details about the MCP server

## Data Source

All data is sourced from the live CPTMSDUG API at https://cptmsdug.dev/mcp.json, providing up-to-date information about the Cape Town Microsoft Developer User Group community.
