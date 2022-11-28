using System.Threading.Tasks;

namespace QualtricsPOC.Interfaces
{
    public interface ISurveyService
    {
        Task<string> CreateServey(string name);
        Task<string> UpdateServey(string surveyId, string name);
        Task PublishSurvey(string surveyId);
        Task ActivateSurvey(string surveyId);

    }
}
