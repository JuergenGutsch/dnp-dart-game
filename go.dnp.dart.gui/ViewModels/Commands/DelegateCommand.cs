using System;

namespace go.dnp.dart.gui.ViewModels.Commands
{
    public class DelegateCommand : IAppCommand
    {
        private readonly Action<object> _executeHandler;
        private readonly Func<object, bool> _canExecuteHandler;

        public DelegateCommand(Action<object> executeHandler)
        {
            _executeHandler = executeHandler;
        }

        public DelegateCommand(Action<object> executeHandler, Func<object, bool> canExecuteHandler)
        {
            _executeHandler = executeHandler;
            _canExecuteHandler = canExecuteHandler;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler != null)
            {
                return _canExecuteHandler(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _executeHandler?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}