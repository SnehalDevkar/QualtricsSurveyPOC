using Newtonsoft.Json;

namespace QualtricsPOC.Entities
{
    public class MailingLibMsg
    {
        public MailingLibMsg() {
            Messages = new MessageOpt();
        }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("messages")]
        public MessageOpt Messages { get; set; }
    }

    public class MessageOpt
    {
        [JsonProperty("en")]
        public string En { get; set; }
    }
}
