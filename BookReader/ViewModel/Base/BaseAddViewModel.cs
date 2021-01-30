using BookReaderLibrary.Model.Commands;
using System;
using System.Windows.Input;

namespace BookReader.ViewModel.Base
{
    public class BaseAddViewModel : BaseViewModel
    {
        public ICommand Add { get; set; }
        public virtual bool CanAddExecute(object sender) => true;
        
        public virtual void AddExecute(object sender) { }

        public BaseAddViewModel()
        {
            Add = new ActionCommand(AddExecute, CanAddExecute);
        }
    }
}
