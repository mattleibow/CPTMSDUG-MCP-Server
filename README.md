# CPTMSDUG MCP Server

A C# library and Model Context Protocol (MCP) server for accessing Cape Town MS Developer User Group (CPTMSDUG) data. This project provides both a .NET library for developers and an MCP server that enables AI assistants to answer questions about the CPTMSDUG community.

## About CPTMSDUG

The **Cape Town MS Developer User Group (CPTMSDUG)** is a vibrant community of developers, architects, and technology enthusiasts passionate about Microsoft technologies and modern development practices. Founded in 2013, CPTMSDUG has grown to serve over **1,885 members** across Cape Town, South Africa, hosting **139 events** with **100+ speakers** and maintaining a **4.7/5 community rating** from 648 reviews.

### Our Mission
We are dedicated to fostering a vibrant community of developers through regular meetups, workshops, and collaborative events that provide a platform for knowledge sharing, networking, and professional growth.

### Core Values
- **Community First** - Building connections and fostering collaboration
- **Continuous Learning** - Staying current with latest technologies
- **Innovation** - Encouraging creative solutions and modern practices
- **Inclusivity** - Welcoming developers of all experience levels

### Technology Focus
**Primary Technologies:** .NET & C#, Microsoft Azure, Artificial Intelligence, Mobile Development, DevOps

**Secondary Technologies:** IoT and Edge Computing, Modern Web Development, Cloud Architecture, Machine Learning, Xamarin/MAUI

### Community Affiliations
- .NET Foundation (part of 174 groups worldwide)
- Microsoft Community

## Community Events

CPTMSDUG typically hosts **monthly events** that are **free to attend**, with sessions lasting 2-3 hours and accommodating 50-100+ attendees. Events are held at various venues including Accso South Africa (Clock Tower, V&A Waterfront), Microsoft Cape Town, BBD Cape Town Offices, and UWC Samsung Future Innovation Lab.

### Current Event Status
No upcoming events are currently scheduled. Stay updated on future events through:
- **Meetup:** [Cape Town MS Dev User Group](https://www.meetup.com/cape-town-ms-dev-user-group/)
- **Discord:** [Join our Discord community](https://discord.gg/cptmsdug)
- **LinkedIn:** [CPTMSDUG LinkedIn](https://www.linkedin.com/company/cptmsdug)

*Events are typically announced monthly, so check back regularly or follow our social channels for the latest updates.*

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
