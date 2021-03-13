using BookReaderLibrary.Model.Commands;
using System;
using System.Windows.Input;

namespace BookReader.ViewModel
{
    public class DeleteMessageShowingViewModel : MainViewModel
    {
        public event Action DeleteSelectedItemEvent;
        public event Action DeleteCloseEvent;


        #region Methods

        #region DeleteSelectedItem command

        public ICommand DeleteSelectedItem { get; set; }

        public void DeleteSelectedItemExecute(object sender) 
        {
            DeleteSelectedItemEvent?.Invoke();

            DisplayRootRegistry.HidePresentation(this);
        }

        public bool CanDeleteSelectedItemExecute(object sender) => true;

        #endregion

        public override void CloseExecute(object sender)
        {
            DeleteCloseEvent?.Invoke();
            base.CloseExecute(sender);
        }

        #endregion

        #region Constructor

        public DeleteMessageShowingViewModel() { }
        public DeleteMessageShowingViewModel(Action SelectedItemHandler, Action DeleteCloseHandler)
        {
            DeleteSelectedItem = new ActionCommand(DeleteSelectedItemExecute, CanDeleteSelectedItemExecute);
            DeleteSelectedItemEvent += SelectedItemHandler;
            DeleteCloseEvent += DeleteCloseHandler;
        }

        #endregion 
    }
}
