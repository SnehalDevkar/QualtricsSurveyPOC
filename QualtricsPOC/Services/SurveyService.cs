using QualtricsPOC.Entities;
using QualtricsPOC.Interfaces;
using System.Threading.Tasks;

namespace QualtricsPOC.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IHttpService _httpService;
        private string datacentreId;
        private string baseUri;
        public SurveyService(IAuthenticationService authenticationService,
            IHttpService httpService)
        {
            _authenticationService = authenticationService;
            _httpService = httpService;
            datacentreId = "fra1";
            baseUri = "https://" + datacentreId + ".qualtrics.com/API/v3/";
        }

        public async Task ActivateSurvey(string surveyId)
        {
            ActivateSurveyReq activateSurveyReq = new ActivateSurveyReq() { 
                 isActive = true
            };

            string uri = baseUri + "surveys/" + surveyId;

            await _httpService.Put(uri, activateSurveyReq);
        }

        public async Task<string> CreateServey(string name)
        {
            CreateSurveyReq createSurvey = new CreateSurveyReq();
            createSurvey.SurveyName = name;
            createSurvey.Language = "EN";
            createSurvey.ProjectCategory = "CORE";

            string uri = baseUri + "survey-definitions";
            string response = await _httpService.Post(uri, createSurvey);

            CreateSurveyRes createSurveyRes = new CreateSurveyRes();
            createSurveyRes = Newtonsoft.Json.JsonConvert.DeserializeObject<CreateSurveyRes>(response);

            return createSurveyRes.Result.SurveyID;
        }

        public async Task PublishSurvey(string surveyId)
        {
            PublishSurveyReq publishSurveyReq = new PublishSurveyReq();
            publishSurveyReq.Published = true;
            publishSurveyReq.Description = "New Survey Version";

            string uri = baseUri + "survey-definitions/" + surveyId + "/versions";

            string response = await _httpService.Post(uri, publishSurveyReq);
        }

        public async Task<string> UpdateServey(string surveyId, string name)
        {
            UpdateServeyReq updateServeyReq = new UpdateServeyReq();
            UpdateServeyRes updateServeyRes = new UpdateServeyRes();

            updateServeyReq.SurveyTitle = name;
            updateServeyReq.Header = "MEP Test Survey Header - " + name;
            updateServeyReq.Footer = "MEP Test Survey Footer - " + name;
            updateServeyReq.SurveyProtection = "PublicSurvey"; // For personal link use "ByInvitation"
            updateServeyReq.SurveyExpiration = "on";
            updateServeyReq.SurveyExpirationDate = "2022-12-30T12:00:00Z";
            updateServeyReq.SurveyTermination = "DefaultMessage";
            updateServeyReq.SaveAndContinue = true;
            updateServeyReq.ProgressBarDisplay = "Text";
            updateServeyReq.PartialData = "+1 week";
            updateServeyReq.BackButton = true;

            string uri = baseUri + "survey-definitions/" + surveyId + "/options";

            string respone =  await _httpService.Put(uri, updateServeyReq);
            updateServeyRes = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateServeyRes>(respone);

            return updateServeyRes.Meta.RequestId;
        }
    }
}
