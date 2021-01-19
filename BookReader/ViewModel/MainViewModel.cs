using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace BookReader.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region AddBook Command

        public ICommand AddBook { get; set; }
        public void AddBookExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new AddBookViewModel());
        }
        public bool CanAddBookExecute(object sender) => true;

        #endregion

        #region AddShelf Command

        public ICommand AddShelf { get; set; }
        public void AddShelfExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new AddShelfViewModel());
        }
        public bool CanAddShelfExecute(object sender) => true;

        #endregion

        public MainViewModel()
        {
            AddBook = new ActionCommand(AddBookExecute, CanAddBookExecute);
            AddShelf = new ActionCommand(AddShelfExecute, CanAddShelfExecute);
        }
    }
}
