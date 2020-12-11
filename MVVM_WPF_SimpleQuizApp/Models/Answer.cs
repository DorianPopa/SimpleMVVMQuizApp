using System.Xml.Serialization;

namespace MVVM_WPF_SimpleQuizApp.Models
{
    public class Answer
    {
        [XmlAttribute("AnswerText")]
        public string AnswerText { get; set; } = string.Empty;

        [XmlAttribute("IsCorrect")]
        public bool IsCorrect { get; set; } = false;

        public bool IsChecked { get; set; } = false;
    }
}
