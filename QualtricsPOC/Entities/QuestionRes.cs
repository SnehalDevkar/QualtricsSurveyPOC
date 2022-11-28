namespace QualtricsPOC.Entities
{
    public class QuestionRes
    {
        public Meta Meta { get; set; }
        public QuestionResult Result { get; set; }
    }

    public class QuestionResult
    {
        public string QuestionID { get; set; }
    }


}
