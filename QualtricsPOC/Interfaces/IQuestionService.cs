using System.Threading.Tasks;

namespace QualtricsPOC.Interfaces
{
    public interface IQuestionService
    {
        Task<string> AddQuestion(string surveyId);
    }
}
