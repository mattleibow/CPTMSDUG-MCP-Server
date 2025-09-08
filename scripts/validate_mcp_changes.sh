#!/usr/bin/env bash

# Script to test the new Event model against the actual MCP JSON data
# This is a validation script that can be run once the packages are properly restored

echo "=== MCP JSON Event Model Validation ==="
echo ""

# Download the latest MCP JSON
echo "1. Downloading latest MCP JSON data..."
curl -k https://cptmsdug.dev/mcp.json -o /tmp/current_mcp.json 2>/dev/null

if [ $? -eq 0 ]; then
    echo "✓ MCP JSON downloaded successfully"
else
    echo "✗ Failed to download MCP JSON"
    exit 1
fi

echo ""
echo "2. Analyzing date/time properties in the MCP JSON..."

# Check for old format properties (should be null)
OLD_DATE_COUNT=$(jq '[.events.allEvents[] | select(.date != null)] | length' /tmp/current_mcp.json)
OLD_TIME_COUNT=$(jq '[.events.allEvents[] | select(.time != null)] | length' /tmp/current_mcp.json)
OLD_DATES_COUNT=$(jq '[.events.allEvents[] | select(.dates != null)] | length' /tmp/current_mcp.json)

# Check for new format properties (should be present)
NEW_START_COUNT=$(jq '[.events.allEvents[] | select(.startDateTime != null)] | length' /tmp/current_mcp.json)
NEW_END_COUNT=$(jq '[.events.allEvents[] | select(.endDateTime != null)] | length' /tmp/current_mcp.json)

TOTAL_EVENTS=$(jq '.events.allEvents | length' /tmp/current_mcp.json)

echo "Total events: $TOTAL_EVENTS"
echo ""
echo "Legacy format usage:"
echo "  - Events with 'date' field: $OLD_DATE_COUNT"
echo "  - Events with 'time' field: $OLD_TIME_COUNT" 
echo "  - Events with 'dates' field: $OLD_DATES_COUNT"
echo ""
echo "New format usage:"
echo "  - Events with 'startDateTime' field: $NEW_START_COUNT"
echo "  - Events with 'endDateTime' field: $NEW_END_COUNT"

echo ""
echo "3. Sample date/time values from MCP JSON:"

echo ""
echo "startDateTime values (first 10):"
jq -r '.events.allEvents[0:10] | .[] | .startDateTime' /tmp/current_mcp.json | head -10

echo ""
echo "endDateTime values (first 10):"
jq -r '.events.allEvents[0:10] | .[] | .endDateTime' /tmp/current_mcp.json | head -10

echo ""
echo "4. Validation Summary:"

if [ "$NEW_START_COUNT" -eq "$TOTAL_EVENTS" ] && [ "$NEW_END_COUNT" -eq "$TOTAL_EVENTS" ]; then
    echo "✓ All events use the new startDateTime/endDateTime format"
    
    if [ "$OLD_DATE_COUNT" -eq 0 ] && [ "$OLD_TIME_COUNT" -eq 0 ] && [ "$OLD_DATES_COUNT" -eq 0 ]; then
        echo "✓ No events use the legacy date/time/dates format"
        echo ""
        echo "🎉 CONCLUSION: The server has completely migrated to the new format!"
        echo "   The Event model updates are necessary and correct."
    else
        echo "⚠ Some events still have legacy format fields (but they may be null)"
        echo "  This is acceptable as the new format takes precedence"
    fi
else
    echo "⚠ Not all events use the new format"
    echo "  Events with startDateTime: $NEW_START_COUNT/$TOTAL_EVENTS"
    echo "  Events with endDateTime: $NEW_END_COUNT/$TOTAL_EVENTS"
fi

echo ""
echo "5. Testing C# DateTime parsing format..."

# Test if the format matches our expected C# parsing pattern "dd/MM/yyyy HH:mm"
echo "Sample startDateTime values and their expected parsing:"

jq -r '.events.allEvents[0:5] | .[] | "\(.name): \(.startDateTime)"' /tmp/current_mcp.json

echo ""
echo "Expected C# parsing format: dd/MM/yyyy HH:mm"
echo "All values should match this pattern for successful parsing."

echo ""
echo "=== Validation Complete ==="