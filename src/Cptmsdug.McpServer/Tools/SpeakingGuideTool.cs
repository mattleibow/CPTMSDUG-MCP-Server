using ModelContextProtocol.Server;
using System.ComponentModel;
using Cptmsdug.Core.Services;

namespace Cptmsdug.McpServer.Tools;

[McpServerToolType]
public partial class SpeakingGuideTool(CptmsdugDataStore dataStore)
{
    [McpServerTool]
    [Description("Get comprehensive information about speaking at CPTMSDUG events. Perfect for answering 'How can I speak at an event?', 'How do I submit a talk?', 'What topics are welcome?', and 'What are the benefits of speaking?'")]
    public async Task<object> GetSpeakingOpportunities()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            CallForSpeakers = new
            {
                Status = data.SpeakingOpportunities.CallForSpeakers ? "OPEN - We're actively looking for speakers!" : "Check back soon",
                SubmissionProcess = new
                {
                    Platform = "Sessionize.com",
                    SubmissionUrl = data.SpeakingOpportunities.SessionizeUrl,
                    ContactEmail = data.SpeakingOpportunities.ContactEmail,
                    ExperienceLevels = data.SpeakingOpportunities.ExperienceLevels
                }
            },
            WelcomedTopics = data.SpeakingOpportunities.WelcomedTopics,
            SpeakerBenefits = data.SpeakingOpportunities.SpeakerBenefits,
            CommunityReach = new
            {
                OnlineMembers = $"{data.CommunityStats.Members}+ community members",
                TotalSpeakers = data.SpeakerStatistics.TotalSpeakers,
                MicrosoftMVPs = data.SpeakerStatistics.MicrosoftMVPs,
                MicrosoftEmployees = data.SpeakerStatistics.MicrosoftEmployees
            },
            ContactEmail = data.SpeakingOpportunities.ContactEmail
        };
    }

    [McpServerTool]
    [Description("Get specific information about topic areas and content that CPTMSDUG is looking for from speakers. Use when someone asks 'What topics should I speak about?' or 'What would be a good topic for CPTMSDUG?'")]
    public async Task<object> GetSpeakingTopics()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            PrimaryTechnologyAreas = data.Technologies.Primary,
            WelcomedTopics = data.SpeakingOpportunities.WelcomedTopics
        };
    }

    [McpServerTool]
    [Description("Get details about the speaker submission process and requirements. Use when someone needs specific details about how to apply to speak.")]
    public async Task<object> GetSubmissionProcess()
    {
        var data = await dataStore.GetDataAsync();

        return new
        {
            SubmissionPlatform = new
            {
                Url = data.SpeakingOpportunities.SessionizeUrl
            },
            ContactInformation = new
            {
                Email = data.SpeakingOpportunities.ContactEmail
            },
            ExperienceLevel = data.SpeakingOpportunities.ExperienceLevels
        };
    }
}