using MVVM_WPF_SimpleQuizApp.Views;
using System.Windows;

namespace MVVM_WPF_SimpleQuizApp
{
    public interface IWindowService
    {
        public void OpenStartWindow();
        public void OpenQuizWindow();
        public void OpenFinalWindow();
    }

    public class WindowService : IWindowService
    {
        private readonly ISessionService _sessionService;
        private readonly IQuizDataService _quizDataService;

        public WindowService(ISessionService sessionService, IQuizDataService quizDataService)
        {
            _sessionService = sessionService;
            _quizDataService = quizDataService;
        }

        public void OpenStartWindow()
        {
            Window startWindow = new StartView(_sessionService, _quizDataService, this);
            startWindow.Show();
        }

        public void OpenQuizWindow()
        {
            Window quizWindow = new QuizView(_sessionService, _quizDataService, this);
            quizWindow.Show();
        }

        public void OpenFinalWindow()
        {
            Window finalWindow = new FinalView(_sessionService);
            finalWindow.Show();
        }
    }
}
