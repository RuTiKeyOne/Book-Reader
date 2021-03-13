using BookReaderLibrary.Model.Commands.Base;
using System;

namespace BookReaderLibrary.Model.Commands
{
    public class ActionCommand : BaseCommand
    {
        private Action<object> _Execute { get; set; }
        private Func<object, bool> _CanExecute { get; set; }


        public ActionCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }


        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execute?.Invoke(parameter);

    }
}
