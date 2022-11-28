using Newtonsoft.Json;

namespace QualtricsPOC.Entities
{
    public class MailingListReq
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }
    }
}
