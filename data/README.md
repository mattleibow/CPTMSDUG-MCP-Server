# CPTMSDUG Data Files

This directory contains structured data extracted from the Cape Town MS Developer User Group (CPTMSDUG) website at https://cptmsdug.dev/

## Data Files

### general.json
Contains general information about the user group including:
- Organization details (name, description, member count, etc.)
- Mission statement and core values
- Statistics (events hosted, years active, speakers)
- Technology focus areas
- Social media links and contact information

### events.json
Contains information about upcoming and recent events including:
- Meetups with dates, times, venues, and descriptions
- Event topics/tags
- Attendee counts and RSVP links
- Venue information
- Special events like conferences

Event types:
- `meetup`: Regular monthly meetups
- `conference`: Large conferences like .NET Conf

### speakers.json
Contains speaker profiles including:
- Speaker names and titles/roles
- Areas of expertise
- Session descriptions
- Profile images
- Past talks and topics

### conferences.json
Contains information about past and future conferences including:
- Conference names and dates
- Attendance statistics
- Session counts and tracks
- Key topics covered
- Links to detailed information

## Usage for MCP Server

This data is structured to help answer common user questions about:

1. **When is the next event?** - Check events.json for upcoming events
2. **What topics does CPTMSDUG cover?** - Check general.json technologies_focus
3. **Who are the speakers?** - Check speakers.json for speaker profiles
4. **How many members does the group have?** - Check general.json statistics
5. **Where do events happen?** - Check events.json venue information
6. **What past conferences were held?** - Check conferences.json
7. **How to contact or join?** - Check general.json social_media and contact info

## Data Freshness

This data was extracted on September 1, 2025. For the most up-to-date information, users should be directed to:
- Main website: https://cptmsdug.dev/
- Meetup group: https://www.meetup.com/cape-town-ms-dev-user-group/
- Twitter: @CPTMSDUG