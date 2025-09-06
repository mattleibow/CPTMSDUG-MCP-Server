# CPTMSDUG MCP Server

A C# library and Model Context Protocol (MCP) server for accessing Cape Town MS Developer User Group (CPTMSDUG) data. This project provides both a .NET library for developers and an MCP server that enables AI assistants to answer questions about the CPTMSDUG community.

## What's Included

- **Cptmsdug.Core**: .NET library for loading CPTMSDUG data from https://cptmsdug.dev/
- **Cptmsdug.McpServer**: MCP server providing AI tools for community information
- **Comprehensive Documentation**: Detailed guides for tools and common use cases

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

## Developer Quick Start

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

## Documentation

- [Common Questions](docs/questions.md) - Questions this server can help answer about CPTMSDUG
- [MCP Server Details](src/Cptmsdug.McpServer/README.md) - Technical details about the MCP server

## Data Source

All data is sourced from the live CPTMSDUG API at https://cptmsdug.dev/, providing up-to-date information about the Cape Town MS Developer User Group community.
