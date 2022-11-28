using System.Threading.Tasks;

namespace QualtricsPOC.Interfaces
{
    public interface IMailService
    {
        Task<string> CreateMailingList(string surveyName, string surveyId);
        Task CreateMailingListContacts(string mailingListId);
        Task<string> CreateLibMessage(string surveyName, string surveyId);
        Task CreateDistributions(string messageId, string mailingListId, string surveyName, string surveyId);
    }
}
