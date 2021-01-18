using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace BookReader.ViewModel
{
    public class MainViewModel : BaseViewModel
    { 
        public ICommand AddBook { get; set; }
        public void AddBookExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new AddBookViewModel()); 
        }
        public bool CanAddBookExecute(object sender) => true;

        public MainViewModel()
        {
            AddBook = new ActionCommand(AddBookExecute, CanAddBookExecute);
            AddBookViewModel = new AddBookViewModel();
        }
    }
}
