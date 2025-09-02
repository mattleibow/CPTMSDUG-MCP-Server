# MCP Tools Reference

This document provides a comprehensive list of all Model Context Protocol (MCP) tools available in the CPTMSDUG MCP Server. All data is sourced from the live CPTMSDUG API at https://cptmsdug.dev/mcp.json.

## Tool Categories

### About Community Tools (`AboutCommunityTool`)

Tools for understanding CPTMSDUG's identity, mission, and values.

| Tool | Description | Use When |
|------|-------------|----------|
| `GetAboutCommunity` | Get comprehensive information about what CPTMSDUG is, including mission, values, technology focus, history, and community statistics | Someone asks "What is CPTMSDUG?" or "What does the community stand for?" |
| `GetMissionAndValues` | Get detailed information about CPTMSDUG's mission, vision, and core values | Someone asks specifically about the community's purpose or what drives the organization |
| `GetTechnologyFocus` | Get information about technologies and platforms that CPTMSDUG focuses on | Someone asks "What technologies does CPTMSDUG cover?" or "Is this community relevant for [specific technology]?" |
| `GetOrganizers` | Get information about CPTMSDUG community organizers and leadership team | Someone asks "Who runs CPTMSDUG?", "Who are the organizers?", or "How can I contact the leadership team?" |

### Upcoming Events Tools (`UpcomingEventsTool`)

Tools for finding and understanding upcoming CPTMSDUG events.

| Tool | Description | Use When |
|------|-------------|----------|
| `GetUpcomingEvents` | Get information about upcoming CPTMSDUG events | Someone asks "What events are coming up?", "When is the next meetup?", or "How do I register for events?" |
| `GetNextEvent` | Get detailed information about the next upcoming event | Someone asks "What's the next event?" or wants specific details about the immediate next meetup |
| `GetEventFormat` | Get information about event format, what to expect, and how to prepare for CPTMSDUG events | Perfect for first-time attendees wanting to know what to expect |

### Speaking Opportunities Tools (`SpeakingGuideTool`)

Tools for speakers and potential speakers.

| Tool | Description | Use When |
|------|-------------|----------|
| `GetSpeakingOpportunities` | Get comprehensive information about speaking at CPTMSDUG events | Someone asks "How can I speak at an event?", "How do I submit a talk?", "What topics are welcome?", or "What are the benefits of speaking?" |
| `GetSpeakingTopics` | Get specific information about topic areas and content that CPTMSDUG is looking for | Someone asks "What topics should I speak about?" or "What would be a good topic for CPTMSDUG?" |
| `GetSubmissionProcess` | Get details about the speaker submission process and requirements | Someone needs specific details about how to apply to speak |

### Sponsorship Tools (`SponsorshipTool`)

Tools for companies interested in sponsoring or partnering with CPTMSDUG.

| Tool | Description | Use When |
|------|-------------|----------|
| `GetSponsorshipOpportunities` | Get information about sponsorship opportunities for companies | Someone asks "How can my company sponsor?" or "What sponsorship options are available?" |
| `GetSponsorshipPackages` | Get specific information about sponsorship packages and corporate partnership options | Companies need detailed sponsorship information |
| `GetVenueHostingOpportunities` | Get information about hosting CPTMSDUG events at company venues | Companies ask "Can we host an event at our office?" |

### Getting Involved Tools (`GetInvolvedTool`)

Tools for people wanting to join and participate in the community.

| Tool | Description | Use When |
|------|-------------|----------|
| `GetHowToJoin` | Get information on how to join and get involved with CPTMSDUG | Someone asks "How can I join?", "How do I get involved?", "Where do I sign up?", or "How can I participate in the community?" |
| `GetContactInformation` | Get contact information and community channels for CPTMSDUG | Someone asks "How do I contact CPTMSDUG?" or needs specific contact details |
| `GetWhoCanAttend` | Get information about who can attend CPTMSDUG events and what to expect | Questions about experience levels, requirements, and event atmosphere |

### Community Connections Tools (`CommunityConnectionsTool`)

Tools for networking and connecting with other community members.

| Tool | Description | Use When |
|------|-------------|----------|
| `GetCommunityConnections` | Get information about connecting with other CPTMSDUG members and community channels | Someone asks "How do I connect with other developers?", "Are there chat channels?", or "Where can I network between events?" |
| `GetDiscordCommunityGuide` | Get information about the Discord community and how to engage effectively | Someone wants to know about the online chat community specifically |
| `GetProfessionalNetworking` | Get information about networking opportunities and professional connections | Career-focused networking questions |

### Learning & Development Tools (`LearningPathsTool`)

Tools for understanding learning opportunities and skill development.

| Tool | Description | Use When |
|------|-------------|----------|
| `GetLearningOpportunities` | Get information about learning and skill development opportunities | Someone asks "How can I improve my skills?", "Are there workshops?", or "What learning resources are available?" |
| `GetSkillDevelopment` | Get information about skill development paths and mentorship | Someone wants guidance on career development or technical growth |
| `GetCertificationSupport` | Get information about certification study groups and support | Someone asks about Microsoft certification preparation or study groups |

### Volunteering Tools (`VolunteerTool`)

Tools for people wanting to volunteer and help organize events.

| Tool | Description | Use When |
|------|-------------|----------|
| `GetVolunteeringOpportunities` | Get information about how to volunteer and help organize CPTMSDUG events | Someone asks "How can I volunteer?", "How can I help organize events?", or "What volunteer roles are available?" |
| `GetOrganizingRoles` | Get specific information about different organizing and volunteer roles | Someone wants details about specific ways to contribute |

### Past Events Tools (`PastEventsTool`)

Tools for exploring CPTMSDUG's event history and past speakers.

| Tool | Description | Use When |
|------|-------------|----------|
| `GetPastEvents` | Get information about past CPTMSDUG events and speakers | Someone asks "What events have you had?", "Who has spoken before?", or wants to see the community's history |
| `GetSpeakerHistory` | Get detailed information about past speakers and their presentations | Someone wants to see the caliber of speakers or find specific past presentations |
| `GetEventStatistics` | Get statistics about past events and community growth | Someone wants to understand the community's track record and growth |

## Data Sources

All tools source their data from the following data structure available at https://cptmsdug.dev/mcp.json:

- **Organization Info**: Name, location, affiliations, founding details
- **Community Statistics**: Member count, events hosted, ratings, speaker statistics
- **Mission & Values**: Primary and secondary mission statements, core values
- **Events**: Upcoming events with agendas, speakers, topics, and event formats
- **Speaker Information**: Past and future speakers, organizer profiles
- **Technologies**: Primary and secondary technology focus areas
- **Contact Information**: Email addresses, social media channels, website details
- **Opportunities**: Speaking, sponsorship, and volunteering opportunities
- **Learning Resources**: Skill development and certification support information

## Tool Implementation Details

- All tools are implemented as C# classes decorated with `[McpServerToolType]`
- Individual methods are decorated with `[McpServerTool]` and include descriptive documentation
- Tools use dependency injection to access the `CptmsdugDataStore` service
- Data is fetched asynchronously and cached for performance
- All tools return structured JSON objects optimized for AI assistant consumption