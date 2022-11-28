using Newtonsoft.Json;
using QualtricsPOC.Entities;
using QualtricsPOC.Interfaces;
using System.Dynamic;
using System.Threading.Tasks;

namespace QualtricsPOC.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IHttpService _httpService;
        private string datacentreId;
        private string baseUri;

        public QuestionService(IHttpService httpService)
        {
            _httpService = httpService;
            datacentreId = "fra1";
            baseUri = "https://" + datacentreId + ".qualtrics.com/API/v3/";
        }

        public async Task<string> AddQuestion(string surveyId)
        {
            QuestionReq questionReq = new QuestionReq();
            string uri = baseUri + "survey-definitions/" + surveyId + "/questions";

            questionReq.QuestionText = "1. Enter your Name";
            questionReq.QuestionType = "TE";
            questionReq.Selector = "SL";
            questionReq.Language = new string[0];
            questionReq.DataExportTag = "QN1";
            questionReq.QuestionID = "QN1";
            string response = await _httpService.Post(uri, questionReq);

            questionReq = new QuestionReq();
            questionReq.QuestionText = "2. Enter your Email Id";
            questionReq.QuestionType = "TE";
            questionReq.Selector = "SL";
            questionReq.Language = new string[0];
            questionReq.DataExportTag = "QN2";
            questionReq.QuestionID = "QN2";
            response = await _httpService.Post(uri, questionReq);

            questionReq = new QuestionReq();
            questionReq.QuestionText = "3. Enter your Organization Name";
            questionReq.QuestionType = "TE";
            questionReq.Selector = "SL";
            questionReq.Language = new string[0];
            questionReq.DataExportTag = "QN3";
            questionReq.QuestionID = "QN3";
            response = await _httpService.Post(uri, questionReq);

            questionReq = new QuestionReq();
            questionReq.QuestionText = "4. Select your gender";
            questionReq.QuestionType = "MC";
            questionReq.Selector = "SAVR";
            questionReq.SubSelector = "TX";
            questionReq.Language = new string[0];
            questionReq.DataExportTag = "QN4";
            questionReq.QuestionID = "QN4";
            questionReq.Choices.Option_1.Display = "Male";
            questionReq.Choices.Option_2.Display = "Female";
            response = await _httpService.Post(uri, questionReq);

            QuestionRes questionRes = JsonConvert.DeserializeObject<QuestionRes>(response);

            return questionRes.Result.QuestionID;

        }
    }
}
