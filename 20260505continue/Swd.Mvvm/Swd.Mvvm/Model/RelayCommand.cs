using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Swd.Mvvm.Model
{
    public class RelayCommand : ICommand
    {

        private readonly Action<object?> _execute;
        private readonly Predicate<object?> _canExecute;

        //Konstruktor
        public RelayCommand(Action<object?> execute, Predicate<object?> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }



        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public event EventHandler? CanExecuteChanged;
        
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
