using MVVM_WPF_SimpleQuizApp.Helpers;
using MVVM_WPF_SimpleQuizApp.Models;
using System;
using System.Windows.Input;

namespace MVVM_WPF_SimpleQuizApp.ViewModels
{
    class QuizWindowViewModel : ViewModelBase
    {
        private readonly ISessionService _sessionService;
        private readonly IQuizDataService _quizDataService;
        private readonly IWindowService _windowService;

        private int _score = 0;

        private Question[] _questions;
        private int _currentQuestionIndex = 0;

        private Question _currentQuestion;
        public Question CurrentQuestion
        {
            get 
            { 
                return _currentQuestion; 
            }
            set
            {
                _currentQuestion = value;
                RaisePropertyChangedEvent(nameof(CurrentQuestion));
            }
        }

        private string _currentQuestionType;
        public string CurrentQuestionType
        {
            get 
            { 
                return _currentQuestionType;
            }
            set
            {
                if (_currentQuestionType == value) return;
                _currentQuestionType = value;
                RaisePropertyChangedEvent(nameof(CurrentQuestionType));
            }
           
        }

        public QuizWindowViewModel(ISessionService sessionService, IQuizDataService quizDataService, IWindowService windowService)
        {
            _sessionService = sessionService;
            _quizDataService = quizDataService;
            _windowService = windowService;

            var difficulty = _sessionService.GetDifficulty();
            _questions = quizDataService.GetQuestionsOfDifficulty(5, difficulty);

            CurrentQuestion = _questions[_currentQuestionIndex];
            CurrentQuestionType = AnswerTemplateSelector.SelectTemplate(CurrentQuestion);
            
        }

        public ICommand NextQuestionCommand
        {
            get { return new DelegateCommand(NextQuestion); }
        }

        private void NextQuestion()
        {
            // Update the score based on the current answers
            bool failed = false;
            foreach(var answ in CurrentQuestion.Answers)
            {
                if (answ.IsCorrect && !answ.IsChecked) failed = true;
                if (!answ.IsCorrect && answ.IsChecked) failed = true;
            }
            if (!failed) _score++;

            // Passed the last question
            if (_currentQuestionIndex >= _questions.Length - 1)
            {
                EndGame();
            }
            else
            {
                // Update current question
                _currentQuestionIndex++;
                CurrentQuestion = _questions[_currentQuestionIndex];
                CurrentQuestionType = AnswerTemplateSelector.SelectTemplate(CurrentQuestion);
            }
        }

        private void EndGame()
        {
            _sessionService.SetScore(_score);
            _windowService.OpenFinalWindow();
            CloseWindowAction();
        }

        public Action CloseWindowAction { get; set; }
    }
}
