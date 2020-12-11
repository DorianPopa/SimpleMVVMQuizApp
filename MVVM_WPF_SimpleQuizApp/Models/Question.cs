using System.Collections.Generic;
using System.Xml.Serialization;

namespace MVVM_WPF_SimpleQuizApp.Models
{
    public class Question
    {
        public int Difficulty { get; set; } 
        public string QuestionText { get; set; }

        [XmlArray]
        [XmlArrayItem(ElementName = "Answer")]
        public List<Answer> Answers { get; set; }
    }
}
