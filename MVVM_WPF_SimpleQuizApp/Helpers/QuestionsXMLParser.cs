using MVVM_WPF_SimpleQuizApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MVVM_WPF_SimpleQuizApp.Helpers
{
    public static class QuestionsXMLParser
    {
        public static List<Question> GetQuestions(string filePath)
        {
            using var fileStream = File.Open(filePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(QuizData));
            var data = (QuizData)serializer.Deserialize(fileStream);

            foreach (var item in data.Questions)
            {
                Console.WriteLine(item.QuestionText);
                foreach (var ans in item.Answers)
                {
                    Console.WriteLine(ans.AnswerText + "  " + ans.IsCorrect);
                }
            }
            return data.Questions;
        } 
    }
}