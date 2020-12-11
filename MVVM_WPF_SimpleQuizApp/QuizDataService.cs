using MVVM_WPF_SimpleQuizApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVVM_WPF_SimpleQuizApp
{
    public interface IQuizDataService
    {
        public List<int> GetDifficulties();
        public Question[] GetQuestionsOfDifficulty(int numberOfQuestions, int difficulty);
    }

    public class QuizDataService : IQuizDataService
    {
        private const string _XMLFilePath = "Questions.xml";
        private readonly List<Question> _questions;

        public QuizDataService()
        {
            _questions = Helpers.QuestionsXMLParser.GetQuestions(_XMLFilePath);
        }

        public List<int> GetDifficulties()
        {
            return _questions.Select(q => q.Difficulty).ToList();
        }

        public Question[] GetQuestionsOfDifficulty(int numberOfQuestions, int difficulty)
        {
            var questions = _questions.Where(q => q.Difficulty == difficulty);
            if (questions.Count() > numberOfQuestions)
                return questions.Take(numberOfQuestions).ToArray();

            return questions.ToArray();
        }
    }
}
