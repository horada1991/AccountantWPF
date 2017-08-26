using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountantMVVM.Helpers
{
    class CommandHandler : ICommand
    {

        #region Constants and Fields


        private readonly Predicate<object> _canExecute;

        private readonly Action<object> _execute;

        #endregion

        #region Constructors and Destructors


        public CommandHandler(Action<object> execute)
            : this(execute, null)
        {
        }

        public CommandHandler(Action<object> execute, Predicate<object> canExecute)
        {
            this._execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this._canExecute = canExecute;
        }

        #endregion

        #region Events


        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;

            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion

        #region Implemented Interfaces

        #region ICommand


        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        #endregion

        #endregion
    }
}
