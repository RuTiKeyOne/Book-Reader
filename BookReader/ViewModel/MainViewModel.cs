using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Actions;
using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.BooksAction;
using BookReaderLibrary.Model.Commands;
using BookReaderLibrary.Model.Dialogs;
using BookReaderLibrary.Model.Json;
using BookReaderLibrary.Model.Shelfs;
using BookReaderLibrary.Model.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace BookReader.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Visibility list state

        private Visibility bookListState = default;
        public Visibility BookListState
        {
            get => bookListState;
            set => SetProperty(ref bookListState, value);
        }

        private Visibility shelfListState = default;
        public Visibility ShelfListState
        {
            get => shelfListState;
            set => SetProperty(ref shelfListState, value);
        }

        #endregion

        private CustomJson Json { get; set; }
        private FileDialog Dialog { get; set; }
        private BookAction BookAction { get; set; }
        private ShelfAction ShelfAction { get; set; }

        #region Book list command

        public ICommand BookListCommand { get; set; }

        public void BookListExecute(object sender) 
        {
            BookAction.FindViews(BooksView, SearchValue);

            BookListState = Visibility.Visible;
            ShelfListState = Visibility.Hidden;
        }

        public bool CanBookListExecute(object sender) => true;

        #endregion

        #region Shelf list command

        public ICommand ShelfListCommand { get; set; }

        public void ShelfListExecute(object sender)
        {
            ShelfAction.FindViews(ShelfsView, SearchValue);

            BookListState = Visibility.Hidden;
            ShelfListState = Visibility.Visible;
        }

        public bool CanShelfListExecute(object sender) => true;

        #endregion

        #region Books view
        public Book SelectedBook { get; set; }

        public ICollectionView BooksView { get; set; }

        private ObservableCollection<Book> books;

        public ObservableCollection<Book> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }

        #endregion

        #region Shelfs view 

        public Shelf SelectedShelf { get; set; }

        public ICollectionView ShelfsView { get; set; }

        private ObservableCollection<Shelf> shelfs;

        public ObservableCollection<Shelf> Shelfs
        {
            get => shelfs;
            set => SetProperty(ref shelfs, value);
        }

        #endregion

        #region Search value

        private string _searchValue = null;
        public string SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                switch (BookListState)
                {
                    case Visibility.Visible:
                        BookAction.FindViews(BooksView, SearchValue);
                        break;
                    case Visibility.Hidden:
                        ShelfAction.FindViews(ShelfsView, SearchValue);
                        break;
                }
            }
        }

        #endregion

        #region AddBook Command

        public ICommand AddBook { get; set; }
        public void AddBookExecute(object sender)
        {
            BookAction.AddBook(Dialog, ref books, sender);
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

        #region Modify Size
        public ICommand ModifySize { get; set; }

        public void ModifySizeExecute(object sender)
        {

        }

        public bool CanModifySizeExecute(object sender) => true;

        #endregion

        #region override Close command

        public override void CloseExecute(object sender)
        {
            Json.Serialize(Books);
            Json.Serialize(Shelfs);
            base.CloseExecute(sender);
        }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            Dialog = new FileDialog();
            AddBook = new ActionCommand(AddBookExecute, CanAddBookExecute);
            AddShelf = new ActionCommand(AddShelfExecute, CanAddShelfExecute);
            Json = new CustomJson();

            books = Json.DeserializeBooks();
            shelfs = Json.DeserializeShelfs();

            BookAction = new BookAction();
            ShelfAction = new ShelfAction();
            ModifySize = new ActionCommand(ModifySizeExecute, CanModifySizeExecute);

            BooksView = CollectionViewSource.GetDefaultView(books);

            ShelfsView = CollectionViewSource.GetDefaultView(shelfs);

            BookListState = Visibility.Visible;
            ShelfListState = Visibility.Hidden;

            BookListCommand = new ActionCommand(BookListExecute, CanBookListExecute);
            ShelfListCommand = new ActionCommand(ShelfListExecute, CanShelfListExecute);


            Singleton.Notifier += GetNameShelf;

        }

        #endregion
        

        public void GetNameShelf(string nameShelf)
        {
            ShelfAction.AddShelf(nameShelf, ref shelfs);
        }
    }
}
