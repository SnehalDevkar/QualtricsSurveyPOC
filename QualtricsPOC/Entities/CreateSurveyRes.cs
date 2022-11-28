namespace QualtricsPOC.Entities
{
    public class CreateSurveyRes
    {
        public Meta Meta { get; set; }
        public CreateSurveyResult Result { get; set; }
    }

    public class CreateSurveyResult
    {
        public string SurveyID { get; set; }
        public string DefaultBlockID { get; set; }

    }
}
