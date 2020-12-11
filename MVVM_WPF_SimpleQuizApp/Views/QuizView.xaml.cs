using MVVM_WPF_SimpleQuizApp.ViewModels;
using System.Windows;

namespace MVVM_WPF_SimpleQuizApp.Views
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizView : Window
    {
        public QuizView(ISessionService sessionService, IQuizDataService quizDataService, IWindowService windowService)
        {
            InitializeComponent();
            var vm = new QuizWindowViewModel(sessionService, quizDataService, windowService);
            DataContext = vm;
            if (vm.CloseWindowAction == null)
                vm.CloseWindowAction = new System.Action(() => Close());
        }
    }
}
