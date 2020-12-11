using MVVM_WPF_SimpleQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_WPF_SimpleQuizApp.Views
{
    /// <summary>
    /// Interaction logic for FinalView.xaml
    /// </summary>
    public partial class FinalView : Window
    {
        public FinalView(ISessionService sessionService)
        {
            InitializeComponent();
            FinalWindowViewModel vm = new FinalWindowViewModel(sessionService);
            DataContext = vm;
            if (vm.CloseWindowAction == null)
                vm.CloseWindowAction = new Action(() => Close());

        }
    }
}
