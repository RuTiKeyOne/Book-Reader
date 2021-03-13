using BookReaderLibrary.Model.Books;
using System.Collections.ObjectModel;

namespace BookReaderLibrary.Model.Lists
{
    public class ShelfListBook
    {
        public string NameShelf { get; set; }
        public ObservableCollection<Book> Books { get; set; }


        public ShelfListBook()
        {
            Books = new ObservableCollection<Book>();
        }

    }
}
