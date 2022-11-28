namespace QualtricsPOC.Entities
{
    public class MailingRes
    {
        public Meta Meta { get; set; }
        public MailingResult Result { get; set; }
    }

    public class MailingResult
    {
        public string Id { get; set; }
    }
}
