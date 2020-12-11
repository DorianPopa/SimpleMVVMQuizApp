using System.Collections.Generic;
using System.Xml.Serialization;

namespace MVVM_WPF_SimpleQuizApp.Models
{
    [XmlRoot("Quiz")]
    public class QuizData
    {
        [XmlArray]
        [XmlArrayItem(ElementName = "Question")]
        public List<Question> Questions { get; set; }
    }
}
