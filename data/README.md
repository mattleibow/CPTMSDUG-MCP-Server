# CPTMSDUG Website Data

This folder contains scraped data from the Cape Town MS Developer User Group website (https://cptmsdug.dev/).

## Files

- `cptmsdug_data.json` - Complete scraped website data in JSON format

## Data Structure

The JSON file contains the following top-level sections:

### `user_group`
Basic information about the Cape Town MS Developer User Group:
- Name, acronym, website
- Member count (1,875+ developers)
- Description and social links
- Timestamp of when data was scraped

### `pages`
Meta information from each page scraped:
- Homepage, About, Meetups, Speakers, Conferences, .NET Conf 2025, Contact
- Page titles and descriptions

### `events`
Array of upcoming meetup events with detailed information:
- **Date** (day, month, year, formatted)
- **Time** (start time and full time range)
- **Title** and description
- **Venue** (physical location)
- **Attendees** (registration count where available)
- **Badges** (event tags/categories)
- **Status** (e.g., "SOLD OUT")
- **Image** (event poster/logo)

### `speakers`
Array of community speakers:
- Name and bio
- Profile image
- Speaking topics/expertise

### `conferences`
Array of past conferences organized by the group:
- Conference title and year
- Description of the event
- Images and branding

### `dotnet_conf`
Information about the annual .NET Conf South Africa event:
- Multi-city tour details
- Venue and date information
- Event focus and content

### `contact`
Contact information and community links

### `summary`
Statistics about the scraped data:
- Total counts of events, speakers, conferences
- Data quality metrics (venues captured, attendee counts, etc.)

## Usage

This data is intended for use with an MCP (Model Context Protocol) server to help answer questions about:
- Upcoming CPTMSDUG events
- Speaker information and expertise
- Historical conferences and community activities
- Venue locations and event logistics
- Community size and engagement

## Data Source

All data was scraped from https://cptmsdug.dev/ on 2025-09-01. No data was augmented or fabricated - this is a direct representation of the website content at that time.