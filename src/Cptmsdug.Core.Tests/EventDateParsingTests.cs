using Cptmsdug.Core.Models;
using System;

namespace Cptmsdug.Core.Tests;

public class EventDateParsingTests
{
    [Theory]
    [InlineData("2025-09-13", "9:00 AM SAST", "2025-09-13T09:00:00+02:00")]
    [InlineData("2025-09-17", "5:30 PM SAST", "2025-09-17T17:30:00+02:00")]
    [InlineData("2025-10-22", "5:30 PM SAST", "2025-10-22T17:30:00+02:00")]
    [InlineData("2025-11-19", "5:30 PM SAST", "2025-11-19T17:30:00+02:00")]
    public void StartTime_WithSeparateDateAndTimeFields_ParsesCorrectly(string date, string time, string expectedDateTimeOffset)
    {
        // Arrange
        var eventItem = new Event
        {
            Date = date,
            Time = time
        };
        var expected = DateTimeOffset.Parse(expectedDateTimeOffset);

        // Act
        var result = eventItem.StartTime;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("2025-01-25", "2025-01-25T00:00:00+02:00")]
    [InlineData("2025-08-27", "2025-08-27T00:00:00+02:00")]
    [InlineData("2025-07-23", "2025-07-23T00:00:00+02:00")]
    [InlineData("2025-05-31", "2025-05-31T00:00:00+02:00")]
    [InlineData("2025-05-21", "2025-05-21T00:00:00+02:00")]
    [InlineData("2025-07-02", "2025-07-02T00:00:00+02:00")]
    [InlineData("2025-06-21", "2025-06-21T00:00:00+02:00")]
    [InlineData("2021-09-30", "2021-09-30T00:00:00+02:00")]
    public void StartTime_WithDateOnlyField_ParsesCorrectlyToStartOfDay(string date, string expectedDateTimeOffset)
    {
        // Arrange
        var eventItem = new Event
        {
            Date = date,
            Time = string.Empty
        };
        var expected = DateTimeOffset.Parse(expectedDateTimeOffset);

        // Act
        var result = eventItem.StartTime;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void StartTime_WithDateRangeFormat_ParsesStartDate()
    {
        // Arrange
        var eventItem = new Event
        {
            Dates = "2025-11-15 to 2025-11-29",
            Date = string.Empty,
            Time = string.Empty
        };
        var expected = new DateTimeOffset(2025, 11, 15, 0, 0, 0, TimeSpan.FromHours(2));

        // Act
        var result = eventItem.StartTime;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void EndTime_WithDateRangeFormat_ParsesEndDate()
    {
        // Arrange
        var eventItem = new Event
        {
            Dates = "2025-11-15 to 2025-11-29",
            Date = string.Empty,
            Time = string.Empty
        };
        var expected = new DateTimeOffset(2025, 11, 29, 0, 0, 0, TimeSpan.FromHours(2));

        // Act
        var result = eventItem.EndTime;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("November 25, 2023 - Cape Town, December 2, 2023 - Johannesburg", "2023-11-25T00:00:00+02:00", "2023-12-02T00:00:00+02:00")]
    [InlineData("November 16, 2024 - Johannesburg, November 30, 2024 - Cape Town", "2024-11-16T00:00:00+02:00", "2024-11-30T00:00:00+02:00")]
    [InlineData("August 24, 2024 - Cape Town, August 31, 2024 - Johannesburg", "2024-08-24T00:00:00+02:00", "2024-08-31T00:00:00+02:00")]
    public void StartTime_And_EndTime_WithMultiCityFormat_ParsesBothDatesCorrectly(string dates, string expectedStart, string expectedEnd)
    {
        // Arrange
        var eventItem = new Event
        {
            Dates = dates,
            Date = string.Empty,
            Time = string.Empty
        };
        var expectedStartTime = DateTimeOffset.Parse(expectedStart);
        var expectedEndTime = DateTimeOffset.Parse(expectedEnd);

        // Act
        var startResult = eventItem.StartTime;
        var endResult = eventItem.EndTime;

        // Assert
        Assert.NotNull(startResult);
        Assert.NotNull(endResult);
        Assert.Equal(expectedStartTime, startResult);
        Assert.Equal(expectedEndTime, endResult);
    }

    [Fact]
    public void StartTime_WithEmptyDateFields_ReturnsNull()
    {
        // Arrange
        var eventItem = new Event
        {
            Date = string.Empty,
            Time = string.Empty,
            Dates = string.Empty
        };

        // Act
        var result = eventItem.StartTime;

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void EndTime_WithEmptyDateFields_ReturnsNull()
    {
        // Arrange
        var eventItem = new Event
        {
            Date = string.Empty,
            Time = string.Empty,
            Dates = string.Empty
        };

        // Act
        var result = eventItem.EndTime;

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void EndTime_WithSingleDateEvent_ReturnsSameAsStartTime()
    {
        // Arrange
        var eventItem = new Event
        {
            Date = "2025-09-13",
            Time = "9:00 AM SAST",
            Dates = string.Empty
        };

        // Act
        var startTime = eventItem.StartTime;
        var endTime = eventItem.EndTime;

        // Assert
        Assert.NotNull(startTime);
        Assert.NotNull(endTime);
        Assert.Equal(startTime, endTime);
    }

    [Theory]
    [InlineData("VS Code Dev Days - Cape Town", "2025-09-13", "9:00 AM SAST")]
    [InlineData("RAG + Building a WordPress Site From Scratch", "2025-09-17", "5:30 PM SAST")]
    [InlineData("Programming with Agents Without It Going Off in Weird Directions", "2025-10-22", "5:30 PM SAST")]
    [InlineData("CPTMSDUG - Games Night", "2025-11-19", "5:30 PM SAST")]
    [InlineData("AI & Azure Expedition", "2025-01-25", "")]
    [InlineData("Cross-Platform .NET Apps with Uno Platform and Azure IoT", "2025-08-27", "")]
    [InlineData("Monkeys in Production and Building an AI Agent with LangChain", "2025-07-23", "")]
    [InlineData("Special Event with Richard Campbell", "2025-05-31", "")]
    [InlineData("Mastering Prompt Engineering + Building Hybrid Apps", "2025-05-21", "")]
    [InlineData("Season of AI Season 4 - Season of Agents", "2025-07-02", "")]
    [InlineData("GitHub Copilot Global Bootcamp - Cape Town", "2025-06-21", "")]
    [InlineData("Azure Bootcamp South Africa 2021", "2021-09-30", "")]
    public void RealWorldEvents_ParseDateTimeCorrectly(string eventName, string date, string time)
    {
        // Arrange
        var eventItem = new Event
        {
            Name = eventName,
            Date = date,
            Time = time,
            Dates = string.Empty
        };

        // Act
        var startTime = eventItem.StartTime;

        // Assert
        Assert.NotNull(startTime);
        
        // Verify the date portion is correct
        var expectedDate = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        Assert.Equal(expectedDate.Year, startTime.Value.Year);
        Assert.Equal(expectedDate.Month, startTime.Value.Month);
        Assert.Equal(expectedDate.Day, startTime.Value.Day);
        
        // Verify timezone is SAST (+2)
        Assert.Equal(TimeSpan.FromHours(2), startTime.Value.Offset);

        // If time is provided, verify it's parsed correctly
        if (!string.IsNullOrEmpty(time))
        {
            if (time.Contains("9:00 AM"))
                Assert.Equal(9, startTime.Value.Hour);
            else if (time.Contains("5:30 PM"))
            {
                Assert.Equal(17, startTime.Value.Hour);
                Assert.Equal(30, startTime.Value.Minute);
            }
        }
        else
        {
            // Date-only events should default to start of day
            Assert.Equal(0, startTime.Value.Hour);
            Assert.Equal(0, startTime.Value.Minute);
        }
    }

    [Theory]
    [InlineData(".NET Conf 2025 South Africa Community Edition", "2025-11-15 to 2025-11-29")]
    public void RealWorldEvents_WithDateRange_ParseCorrectly(string eventName, string dates)
    {
        // Arrange
        var eventItem = new Event
        {
            Name = eventName,
            Date = string.Empty,
            Time = string.Empty,
            Dates = dates
        };

        // Act
        var startTime = eventItem.StartTime;
        var endTime = eventItem.EndTime;

        // Assert
        Assert.NotNull(startTime);
        Assert.NotNull(endTime);
        Assert.Equal(new DateTimeOffset(2025, 11, 15, 0, 0, 0, TimeSpan.FromHours(2)), startTime);
        Assert.Equal(new DateTimeOffset(2025, 11, 29, 0, 0, 0, TimeSpan.FromHours(2)), endTime);
    }

    [Theory]
    [InlineData(".NET Conf 2024 South Africa Community Edition", "November 16, 2024 - Johannesburg, November 30, 2024 - Cape Town")]
    [InlineData("Microsoft Season of AI 2024", "August 24, 2024 - Cape Town, August 31, 2024 - Johannesburg")]
    [InlineData(".NET Conf 2023 South Africa Community Edition", "November 25, 2023 - Cape Town, December 2, 2023 - Johannesburg")]
    public void RealWorldEvents_WithMultiCityDates_ParseCorrectly(string eventName, string dates)
    {
        // Arrange
        var eventItem = new Event
        {
            Name = eventName,
            Date = string.Empty,
            Time = string.Empty,
            Dates = dates
        };

        // Act
        var startTime = eventItem.StartTime;
        var endTime = eventItem.EndTime;

        // Assert
        Assert.NotNull(startTime);
        Assert.NotNull(endTime);
        
        // Verify timezone is SAST (+2)
        Assert.Equal(TimeSpan.FromHours(2), startTime.Value.Offset);
        Assert.Equal(TimeSpan.FromHours(2), endTime.Value.Offset);
        
        // Verify start time is before end time
        Assert.True(startTime < endTime, $"Start time {startTime} should be before end time {endTime}");

        // Event-specific assertions
        switch (eventName)
        {
            case ".NET Conf 2024 South Africa Community Edition":
                Assert.Equal(new DateTimeOffset(2024, 11, 16, 0, 0, 0, TimeSpan.FromHours(2)), startTime);
                Assert.Equal(new DateTimeOffset(2024, 11, 30, 0, 0, 0, TimeSpan.FromHours(2)), endTime);
                break;
            case "Microsoft Season of AI 2024":
                Assert.Equal(new DateTimeOffset(2024, 8, 24, 0, 0, 0, TimeSpan.FromHours(2)), startTime);
                Assert.Equal(new DateTimeOffset(2024, 8, 31, 0, 0, 0, TimeSpan.FromHours(2)), endTime);
                break;
            case ".NET Conf 2023 South Africa Community Edition":
                Assert.Equal(new DateTimeOffset(2023, 11, 25, 0, 0, 0, TimeSpan.FromHours(2)), startTime);
                Assert.Equal(new DateTimeOffset(2023, 12, 2, 0, 0, 0, TimeSpan.FromHours(2)), endTime);
                break;
        }
    }

    [Theory]
    [InlineData("invalid-date", "")]
    [InlineData("", "invalid-time")]
    [InlineData("2025-13-45", "25:99 PM SAST")] // Invalid date and time
    public void StartTime_WithInvalidDateFormats_ReturnsNull(string date, string time)
    {
        // Arrange
        var eventItem = new Event
        {
            Date = date,
            Time = time,
            Dates = string.Empty
        };

        // Act
        var result = eventItem.StartTime;

        // Assert
        Assert.Null(result);
    }

    [Theory]
    [InlineData("invalid date range")]
    [InlineData("2025-13-45 to 2025-15-99")] // Invalid date format
    [InlineData("February 30, 2025 - Cape Town, March 32, 2025 - Johannesburg")] // Invalid dates
    public void StartTime_WithInvalidDatesField_ReturnsNull(string dates)
    {
        // Arrange
        var eventItem = new Event
        {
            Date = string.Empty,
            Time = string.Empty,
            Dates = dates
        };

        // Act
        var result = eventItem.StartTime;

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void IsUpcoming_WithFutureDate_ReturnsTrue()
    {
        // Arrange
        var eventItem = new Event
        {
            Date = "2030-12-31", // Far future date
            Time = "9:00 AM SAST"
        };

        // Act & Assert
        Assert.True(eventItem.IsUpcoming);
        Assert.False(eventItem.IsPast);
    }

    [Fact]
    public void IsPast_WithPastDate_ReturnsTrue()
    {
        // Arrange
        var eventItem = new Event
        {
            Date = "2020-01-01", // Past date
            Time = "9:00 AM SAST"
        };

        // Act & Assert
        Assert.True(eventItem.IsPast);
        Assert.False(eventItem.IsUpcoming);
    }

    [Fact]
    public void IsUpcoming_And_IsPast_WithNullStartTime_ReturnsFalse()
    {
        // Arrange
        var eventItem = new Event
        {
            Date = string.Empty,
            Time = string.Empty,
            Dates = string.Empty
        };

        // Act & Assert
        Assert.False(eventItem.IsUpcoming);
        Assert.False(eventItem.IsPast);
    }

    [Fact]
    public void IsUpcoming_And_IsPast_AreMutuallyExclusive()
    {
        // Test with past event
        var pastEvent = new Event
        {
            Date = "2020-01-01",
            Time = "9:00 AM SAST"
        };

        Assert.True(pastEvent.IsPast);
        Assert.False(pastEvent.IsUpcoming);

        // Test with future event
        var futureEvent = new Event
        {
            Date = "2030-12-31",
            Time = "9:00 AM SAST"
        };

        Assert.True(futureEvent.IsUpcoming);
        Assert.False(futureEvent.IsPast);
    }
}