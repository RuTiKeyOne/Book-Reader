using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace BookReader.ViewModel
{
    public class DeleteMessageShowingViewModel : MainViewModel
    {
        public ICommand DeleteSelectedItem { get; set; }

        public void DeleteSelectedItemExecute(object sender)
        {
            
        }

        public bool CanDeleteSelectedItemExecute(object sender) => true;

        public DeleteMessageShowingViewModel()
        {
            DeleteSelectedItem = new ActionCommand(DeleteSelectedItemExecute, CanDeleteSelectedItemExecute);
        }
    }
}
