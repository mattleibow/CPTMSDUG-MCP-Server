using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class LearningPathsTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get information about skill development and learning opportunities through CPTMSDUG. Perfect for answering 'How can I improve my skills?', 'What can I learn?', and 'Are there mentorship opportunities?'")]
    public async Task<object> GetLearningOpportunities()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            LearningPlatforms = new
            {
                InPersonEvents = new
                {
                    EventTypes = data.Events.Types,
                    Frequency = data.Events.Format.Frequency,
                    Duration = data.Events.Format.Duration
                },
                CommunityDiscussion = new
                {
                    Discord = data.Contact.SocialMedia.Discord
                }
            },
            TechnologyAreas = new
            {
                PrimaryFocus = data.Technologies.Primary,
                SecondaryFocus = data.Technologies.Secondary
            },
            ContactInformation = new
            {
                Email = data.Contact.Email,
                SocialMedia = data.Contact.SocialMedia
            }
        };
    }

    [McpServerTool]
    [Description("Get information about mentorship and networking opportunities in the CPTMSDUG community. Use when someone asks about getting guidance or connecting with experienced developers.")]
    public async Task<object> GetMentorshipAndNetworking()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            CommunityMentors = new
            {
                MicrosoftMVPs = data.SpeakerStatistics.MicrosoftMVPs,
                MicrosoftEmployees = data.SpeakerStatistics.MicrosoftEmployees,
                ExperiencedSpeakers = data.SpeakerStatistics.LocalExperts
            },
            NetworkingOpportunities = new
            {
                MonthlyEvents = new
                {
                    Attendance = data.Events.Format.Capacity
                },
                OnlineCommunity = new
                {
                    Discord = data.Contact.SocialMedia.Discord
                }
            },
            CommunityValues = data.Mission.Values
        };
    }

    [McpServerTool]
    [Description("Get information about hands-on workshops and practical learning opportunities at CPTMSDUG events. Perfect for those who want to know about technical labs and workshop formats.")]
    public async Task<object> GetWorkshopsAndHandsOnLearning()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            TechnicalAreas = new
            {
                PrimaryTechnologies = data.Technologies.Primary
            },
            EventTypes = data.Events.Types
        };
    }
}