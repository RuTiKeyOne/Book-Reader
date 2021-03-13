using BookReaderLibrary.Model.Books;
using System.Collections.ObjectModel;

namespace BookReaderLibrary.Model.Lists
{
    public class ShelfListBook
    {
        #region Properties 

        public string NameShelf { get; set; }

        public ObservableCollection<Book> Books { get; set; }

        #endregion

        #region Constructor

        public ShelfListBook()
        {
            Books = new ObservableCollection<Book>();
        }

        #endregion
    }
}
