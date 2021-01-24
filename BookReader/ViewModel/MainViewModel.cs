using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.Commands;
using BookReaderLibrary.Model.Dialogs;
using BookReaderLibrary.Model.Json;
using BookReaderLibrary.Model.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BookReader.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private CustomJson Json { get; set; }
        private FileDialog Dialog { get; set; }
        private Book BookAdd { get; set; }

        #region Window size


        #endregion

        #region Books

        private ObservableCollection<string> books;

        public ObservableCollection<string> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }

        #endregion

        #region AddBook Command

        public ICommand AddBook { get; set; }
        public void AddBookExecute(object sender)
        {
            BookAdd.AddBook(Dialog, ref books, sender);
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

        public ICommand ModifySize { get; set; }

        public void ModifySizeExecute(object sender)
        {

        }

        public bool CanModifySizeExecute(object sender) => true;

        public override void CloseExecute(object sender)
        {
            Json.Serialize(Books);
            base.CloseExecute(sender);
        }

        public MainViewModel()
        {
            Dialog = new FileDialog();
            AddBook = new ActionCommand(AddBookExecute, CanAddBookExecute);
            AddShelf = new ActionCommand(AddShelfExecute, CanAddShelfExecute);
            Json = new CustomJson();
            books =  Json.Deserialize();
            BookAdd = new Book();
            ModifySize = new ActionCommand(ModifySizeExecute, CanModifySizeExecute);


        }
    }
}
