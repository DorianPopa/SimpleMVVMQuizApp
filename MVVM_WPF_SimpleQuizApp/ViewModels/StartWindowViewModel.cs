using MVVM_WPF_SimpleQuizApp.Helpers;
using System;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVM_WPF_SimpleQuizApp.ViewModels
{
    class StartWindowViewModel : ViewModelBase
    {
        private readonly ISessionService _sessionService;
        private readonly IQuizDataService _quizDataService;
        private readonly IWindowService _windowService;

        private string _username;
        public string Username { 
            get 
            {
                return _username;
            }
            set
            {
                if (_username == value) return;
                _username = value;
            }
        }

        private readonly CollectionView _difficulties;
        public CollectionView Difficulties { 
            get 
            { 
                return _difficulties; 
            } 
        }

        private int _selectedDifficulty;
        public int SelectedDifficulty {
            get 
            { 
                return _selectedDifficulty;
            } 
            set 
            { 
                if (_selectedDifficulty == value) return;
                _selectedDifficulty = value;
            }
        }

        public StartWindowViewModel(ISessionService sessionService, IQuizDataService quizDataService, IWindowService windowService)
        {
            _sessionService = sessionService;
            _quizDataService = quizDataService;
            _windowService = windowService;

            _difficulties = new CollectionView(_quizDataService.GetDifficulties());
        }

        public ICommand StartGameCommand
        {
            get { return new DelegateCommand(StartGame); }
        }

        private void StartGame()
        {
            Console.WriteLine("Game Started with: " + _username + " and difficulty " + _selectedDifficulty);
            _sessionService.SetUsername(_username);
            _sessionService.SetDifficulty(_selectedDifficulty);
            _windowService.OpenQuizWindow();
            CloseWindowAction();
        }

        public Action CloseWindowAction { get; set; }
    }
}
