using MVVM_WPF_SimpleQuizApp.Helpers;
using System;
using System.Windows.Input;

namespace MVVM_WPF_SimpleQuizApp.ViewModels
{
    class FinalWindowViewModel : ViewModelBase
    {
        private readonly ISessionService _sessionService;

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChangedEvent(nameof(Username));
            }
        }

        private string _score;
        public string Score
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChangedEvent(nameof(Score));
            }
        }

        public ICommand CloseWindow
        {
            get { return new DelegateCommand(DoCloseWindow); }
        }

        public Action CloseWindowAction { get; set; }

        private void DoCloseWindow() 
        {
            CloseWindowAction();
        }


        public FinalWindowViewModel(ISessionService sessionService)
        {
            _sessionService = sessionService;

            Username = sessionService.GetUsername();
            Score = sessionService.GetScore().ToString();
        }
    }
}
