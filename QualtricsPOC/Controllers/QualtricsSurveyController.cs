using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QualtricsPOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QualtricsPOC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QualtricsSurveyController : ControllerBase
    {
        private readonly ILogger<QualtricsSurveyController> _logger;
        private readonly ISurveyService _surveyService;
        private readonly IQuestionService _questionService;
        private readonly IMailService _mailService;
        private readonly IAuthenticationService _authenticationService;
        public QualtricsSurveyController(ISurveyService surveyService,
            ILogger<QualtricsSurveyController> logger,
            IQuestionService questionService,
            IMailService mailService,
            IAuthenticationService authenticationService)
        {
            _surveyService = surveyService;
            _logger = logger;
            _questionService = questionService;
            _mailService = mailService;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public async Task<string> QualtricsSurvey()
        {
            try
            {
                string surveyName = "MEP 28th Nov 1 - API";
                await _authenticationService.GenerateAccessToken("manage:all");
                string surveyId = await _surveyService.CreateServey(surveyName);
                await _surveyService.UpdateServey(surveyId, surveyName);
                await _questionService.AddQuestion(surveyId);
                await _surveyService.PublishSurvey(surveyId);
                await _surveyService.ActivateSurvey(surveyId);
                string mailingListId = await _mailService.CreateMailingList(surveyName, surveyId); 
                await _mailService.CreateMailingListContacts(mailingListId);
                string messageId = await _mailService.CreateLibMessage(surveyName, surveyId);
                await _mailService.CreateDistributions(messageId, mailingListId, surveyName, surveyId);
                return surveyId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
