using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Commands;
using BookReaderLibrary.Model.Dialogs;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace BookReader.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private FileDialog Dialog { get; set; }

        private ObservableCollection<string> books = new ObservableCollection<string>() { "Book 1", "Book 2" };

        public ObservableCollection<string> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }

        #region AddBook Command

        public ICommand AddBook { get; set; }
        public void AddBookExecute(object sender)
        {

            Books.Add(Dialog.GetFile((sender as string)));         
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
            Dialog = new FileDialog();
            AddBook = new ActionCommand(AddBookExecute, CanAddBookExecute);
            AddShelf = new ActionCommand(AddShelfExecute, CanAddShelfExecute);
        }
    }
}
