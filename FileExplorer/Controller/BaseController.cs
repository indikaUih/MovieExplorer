using System;
using System.Windows.Input;

namespace FileExplorer.Controller
{
    public class BaseController : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<Object> _executeCommandHandler;
        private readonly Func<string, bool> _commandCanExectute;


        public BaseController(Action<Object> commandHandler, Func<string, bool> commandCanExecute)
        {
            _executeCommandHandler = commandHandler;
            _commandCanExectute = commandCanExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                return _commandCanExectute(parameter.ToString());
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                _executeCommandHandler(parameter.ToString());
            }
        }


        public void RefreshCanExecute()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}