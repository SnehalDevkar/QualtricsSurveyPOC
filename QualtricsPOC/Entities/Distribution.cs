using Newtonsoft.Json;

namespace QualtricsPOC.Entities
{
    public class Distribution
    {
        public Distribution() { 
            Message = new DistMessage();
            Recipients = new DisrRecipient();
            Header = new DistHeader();  
            SurveyLink = new DistSurveyLink();
        }
        [JsonProperty("message")]
        public DistMessage Message { get; set; }

        [JsonProperty("recipients")]
        public DisrRecipient Recipients { get; set; }

        [JsonProperty("header")]
        public DistHeader Header { get; set; }

        [JsonProperty("surveyLink")]
        public DistSurveyLink SurveyLink { get; set; }

        [JsonProperty("sendDate")]
        public string SendDate { get; set; }
    }

    public class DistMessage {
        [JsonProperty("libraryId")]
        public string LibraryId { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }
    }

    public class DisrRecipient
    {
        [JsonProperty("mailingListId")]
        public string MailingListId { get; set; }

    }

    public class DistHeader
    {
        [JsonProperty("fromEmail")]
        public string FromEmail { get; set; }

        [JsonProperty("replyToEmail")]
        public string ReplyToEmail { get; set; }

        [JsonProperty("fromName")]
        public string FromName { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }
    }

    public class DistSurveyLink
    {
        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }

        [JsonProperty("surveyId")]
        public string SurveyId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
