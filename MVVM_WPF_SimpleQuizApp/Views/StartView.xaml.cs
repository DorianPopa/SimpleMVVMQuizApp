using MVVM_WPF_SimpleQuizApp.ViewModels;
using System.Windows;

namespace MVVM_WPF_SimpleQuizApp.Views
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : Window
    {
        public StartView(ISessionService sessionService, IQuizDataService quizDataService, IWindowService windowService)
        {
            InitializeComponent();
            var vm = new StartWindowViewModel(sessionService, quizDataService, windowService);
            DataContext = vm;
            if (vm.CloseWindowAction == null)
                vm.CloseWindowAction = new System.Action(() => Close());
        }
    }
}
