namespace QualtricsPOC.Entities
{
    public class UpdateServeyReq
    {
        public string SurveyTitle { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string SurveyProtection { get; set; }
        public string SurveyExpiration { get; set; }
        public string SurveyExpirationDate { get; set; }
        public string SurveyTermination { get; set; }
        public bool SaveAndContinue { get; set; }
        public string ProgressBarDisplay { get; set; }
        public string PartialData { get; set; }
        public bool BackButton { get; set; }
    }
}
