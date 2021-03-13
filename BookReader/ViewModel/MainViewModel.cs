using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Actions;
using BookReaderLibrary.Model.BooksAction;
using BookReaderLibrary.Model.Commands;
using BookReaderLibrary.Model.Windows;
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
            BookAction.AddBook(Dialog, ref books);
            Json.Serialize(Books);
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

        #region Constructor
        public MainViewModel()
        {
            AddBook = new ActionCommand(AddBookExecute, CanAddBookExecute);
            AddShelf = new ActionCommand(AddShelfExecute, CanAddShelfExecute);

            books = Json.DeserializeBooks();
            shelves = Json.DeserializeShelves();

            ShelfAction = new ShelfAction();

            BooksView = CollectionViewSource.GetDefaultView(books);

            ShelfsView = CollectionViewSource.GetDefaultView(shelves);

            BookListState = Visibility.Visible;
            ShelfListState = Visibility.Hidden;

            BookListCommand = new ActionCommand(BookListExecute, CanBookListExecute);
            ShelfListCommand = new ActionCommand(ShelfListExecute, CanShelfListExecute);

            Mode = SelectionMode.Selection;

            Singleton.NotifierAddShelf += GetMessageAddShelf;

            }

        #endregion

        #region Methods 

        public void GetMessageAddShelf(string nameShelf)
        {
            ShelfAction.AddShelf(nameShelf, ref shelves, Dialog);
            Json.Serialize(Shelves);
        }

        #endregion
    }
}
    