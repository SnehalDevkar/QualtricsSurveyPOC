using Newtonsoft.Json;

namespace QualtricsPOC.Entities
{
    public class QuestionReq
    {
        public QuestionReq() {
            Choices = new QuestionChoice();
        }

        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public string Selector { get; set; }
        public string SubSelector { get; set; }
        public QuestionChoice Choices { get; set; }
        public string[] Language { get; set; }
        public string DataExportTag { get; set; }
        public string QuestionID { get; set; }
    }

    public class QuestionChoice {

        public QuestionChoice() { 
            Option_1 = new QuestionChoiceOpt();
            Option_2 = new QuestionChoiceOpt();
        }

        [JsonProperty("1")]
        public QuestionChoiceOpt Option_1;

        [JsonProperty("2")]
        public QuestionChoiceOpt Option_2;
    }

    public class QuestionChoiceOpt {
        public string Display { get; set; }
    }
}
