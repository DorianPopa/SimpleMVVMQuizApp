using System;
using System.Windows.Input;

namespace MVVM_WPF_SimpleQuizApp.Helpers
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;
        
        public DelegateCommand(Action action)
        {
            _action = action;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
