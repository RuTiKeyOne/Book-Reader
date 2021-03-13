using BookReaderLibrary.Model.Commands;
using System.Windows.Input;

namespace BookReader.ViewModel.Base
{
    public class BaseAddViewModel : BaseViewModel
    {
        #region Add command

        public ICommand Add { get; set; }
        public virtual bool CanAddExecute(object sender) => true;
        
        public virtual void AddExecute(object sender) { }

        #endregion


        public BaseAddViewModel()
        {
            Add = new ActionCommand(AddExecute, CanAddExecute);
        }

    }
}
