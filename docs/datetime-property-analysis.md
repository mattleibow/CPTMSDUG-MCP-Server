# Complete Date/Time Property Analysis

Generated: September 8, 2025
Source: https://cptmsdug.dev/mcp.json

## Summary

- **Total Events**: 16
- **Format**: dd/MM/yyyy HH:mm
- **Timezone**: SAST (UTC+2)
- **Legacy Properties**: None (all null: date, time, dates)
- **New Properties**: 100% coverage (startDateTime, endDateTime)

## All Unique startDateTime Values:
```
02/07/2025 17:30
13/09/2025 09:00
15/11/2025 09:00
16/11/2024 09:00
17/09/2025 17:30
19/11/2025 17:30
21/05/2025 17:30
21/06/2025 09:00
22/10/2025 17:30
23/07/2025 17:30
24/08/2024 09:00
25/01/2025 09:00
25/11/2023 09:00
27/08/2025 17:30
30/09/2021 09:00
31/05/2025 17:30
```

## All Unique endDateTime Values:
```
02/07/2025 20:30
02/12/2023 17:00
13/09/2025 13:00
17/09/2025 20:30
19/11/2025 20:30
21/05/2025 20:30
21/06/2025 17:00
22/10/2025 20:30
23/07/2025 20:30
25/01/2025 17:00
27/08/2025 20:30
29/11/2025 17:00
30/09/2021 17:00
30/11/2024 17:00
31/05/2025 20:30
31/08/2024 17:00
```

## Event Names with Date/Time:
```
VS Code Dev Days - Cape Town: 13/09/2025 09:00 - 13/09/2025 13:00
RAG + Building a WordPress Site From Scratch: 17/09/2025 17:30 - 17/09/2025 20:30
Programming with Agents Without It Going Off in Weird Directions: 22/10/2025 17:30 - 22/10/2025 20:30
CPTMSDUG - Games Night: 19/11/2025 17:30 - 19/11/2025 20:30
.NET Conf 2025 South Africa Community Edition: 15/11/2025 09:00 - 29/11/2025 17:00
AI & Azure Expedition: 25/01/2025 09:00 - 25/01/2025 17:00
.NET Conf 2024 South Africa Community Edition: 16/11/2024 09:00 - 30/11/2024 17:00
Microsoft Season of AI 2024: 24/08/2024 09:00 - 31/08/2024 17:00
.NET Conf 2023 South Africa Community Edition: 25/11/2023 09:00 - 02/12/2023 17:00
Azure Bootcamp South Africa 2021: 30/09/2021 09:00 - 30/09/2021 17:00
Cross-Platform .NET Apps with Uno Platform and Azure IoT: 27/08/2025 17:30 - 27/08/2025 20:30
Monkeys in Production and Building an AI Agent with LangChain: 23/07/2025 17:30 - 23/07/2025 20:30
Special Event with Richard Campbell: 31/05/2025 17:30 - 31/05/2025 20:30
Mastering Prompt Engineering + Building Hybrid Apps: 21/05/2025 17:30 - 21/05/2025 20:30
Season of AI Season 4 - Season of Agents: 02/07/2025 17:30 - 02/07/2025 20:30
GitHub Copilot Global Bootcamp - Cape Town: 21/06/2025 09:00 - 21/06/2025 17:00
```

## Patterns Observed

### Time Patterns:
- **09:00**: Conference/all-day events (7 events)
- **17:30**: Regular evening meetups (9 events)
- **13:00**: Workshop/half-day events end times
- **17:00**: Conference/all-day events end times
- **20:30**: Regular meetup end times

### Event Types by Time:
- **Morning starts (09:00)**: Conferences, bootcamps, workshops
- **Evening starts (17:30)**: Regular monthly meetups, technical sessions

### Duration Patterns:
- **3 hours (17:30-20:30)**: Standard meetup duration
- **4 hours (09:00-13:00)**: Workshop format
- **8 hours (09:00-17:00)**: Full day events
- **Multi-day**: Conference events span multiple days

## Format Validation
✅ All values match the expected C# parsing format: `dd/MM/yyyy HH:mm`
✅ All dates are valid and parseable
✅ Consistent timezone handling (SAST = UTC+2)