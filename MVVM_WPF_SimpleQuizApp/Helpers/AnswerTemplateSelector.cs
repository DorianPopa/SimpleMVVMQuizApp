using MVVM_WPF_SimpleQuizApp.Models;

namespace MVVM_WPF_SimpleQuizApp.Helpers
{
    public static class AnswerTemplateSelector
    {
        public static string SelectTemplate(Question question)
        {
            var answerList = question.Answers;

            var correctAnswers = 0;
            foreach(var answ in answerList)
                if (answ.IsCorrect) correctAnswers++;

            if (correctAnswers == 1) 
                return "SingleAnswer";
            if(correctAnswers > 1)
                return "MultiAnswer";

            return null;
        }
    }
}
