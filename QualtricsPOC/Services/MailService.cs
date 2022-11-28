using Newtonsoft.Json;
using QualtricsPOC.Entities;
using QualtricsPOC.Interfaces;
using System.Threading.Tasks;

namespace QualtricsPOC.Services
{
    public class MailService : IMailService
    {
        private readonly IHttpService _httpService;
        private string directoryId;
        private string ownerId;
        private string datacentreId;
        private string libraryId;
        private string baseUri;

        public MailService(IHttpService httpService)
        {
            _httpService = httpService;
            directoryId = "POOL_2dJQYj8hffPmJJo";
            ownerId = "UR_0OCBbjiis2vlzHU";
            datacentreId = "fra1";
            libraryId = "UR_0OCBbjiis2vlzHU";
            baseUri = "https://" + datacentreId + ".qualtrics.com/API/v3/";
        }

        public async Task CreateDistributions(string messageId, string mailingListId, string surveyName, string surveyId)
        {
            Distribution distribution = new Distribution();
            distribution.Message.LibraryId = libraryId;
            distribution.Message.MessageId = messageId;
            distribution.Recipients.MailingListId = mailingListId;
            distribution.Header.FromEmail = "noreply@qemailserver.com";
            distribution.Header.ReplyToEmail = "snehal.devkar@ey.com";
            distribution.Header.FromName = "Snehal Devkar";
            distribution.Header.Subject = "Survey: " + surveyName;
            distribution.SurveyLink.ExpirationDate = "2022-12-30T20:00:00Z";
            distribution.SurveyLink.SurveyId = surveyId;
            distribution.SurveyLink.Type = "Anonymous";// for public link use "Individual";
            distribution.SendDate = "2022-10-12T18:06:30Z";

            string uri = baseUri + "distributions";

            await _httpService.Post(uri, distribution);
        }

        public async Task<string> CreateLibMessage(string surveyName, string surveyId)
        {
            MailingLibMsg mailingLibMsg = new MailingLibMsg();
            MailingRes mailingRes = new MailingRes();
            mailingLibMsg.Description = "Invite mail for - " + surveyName;
            mailingLibMsg.Category = "invite";
            mailingLibMsg.Messages.En = "<p>&nbsp;</p><p><strong>Follow this link to the Survey "+ surveyName + ": </strong><br />${l://SurveyLink?d=Take the Survey}</p><p>Or copy and paste the URL below into your internet browser:<br />${l://SurveyURL}</p><p><small>Follow the link to opt out of future emails:<br />${l://OptOutLink?d=Click here to unsubscribe}</small></p>";

            string uri = baseUri + "libraries/" + libraryId + "/messages";

            string response = await _httpService.Post(uri, mailingLibMsg);
            mailingRes = JsonConvert.DeserializeObject<MailingRes>(response);

            return mailingRes.Result.Id;
        }

        public async Task<string> CreateMailingList(string surveyName, string surveyId)
        {
            MailingListReq mailingListReq = new MailingListReq()
            {
                Name = "MEPMailingList: " + surveyName,
                OwnerId = ownerId
            };
            MailingRes mailingListRes = new MailingRes();

            string uri = baseUri + "directories/" + directoryId + "/mailinglists";

            string response = await _httpService.Post(uri, mailingListReq);
            mailingListRes = JsonConvert.DeserializeObject<MailingRes>(response);

            return mailingListRes.Result.Id;
        }

        public async Task CreateMailingListContacts(string mailingListId)
        {
            MailingListContactReq mailingListContactReq = new MailingListContactReq();
            mailingListContactReq.FirstName = "Snehal";
            mailingListContactReq.LastName = "Devkar";
            mailingListContactReq.Email = "snehaldevkar1994@gmail.com";
            mailingListContactReq.Language = "en";
            mailingListContactReq.Unsubscribed = false;

            string uri = baseUri + "directories/" + directoryId + "/mailinglists/" + mailingListId + "/contacts";

            await _httpService.Post(uri, mailingListContactReq);
        }
    }
}
