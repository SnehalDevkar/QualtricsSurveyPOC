using Newtonsoft.Json;

namespace QualtricsPOC.Entities
{
    public class MailingListContactReq
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("unsubscribed")]
        public bool Unsubscribed { get; set; }
    }
}
