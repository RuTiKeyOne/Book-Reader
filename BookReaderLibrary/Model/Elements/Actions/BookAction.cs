using BookReaderLibrary.Model.Base;
using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.Dialogs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BookReaderLibrary.Model.BooksAction
{
    public class BookAction : BaseAction
    {
        #region Add

        public override void AddBook(FileDialog dialog, ref ObservableCollection<Book> books)
        {
            IsSame = AddHelper(dialog, books);
            if (IsSame)
            {
               books.Add(new Book {NameBook = IntermediateResultNameBook, Path = InternadiateResultPathBook });
            }
        }

        public override ObservableCollection<Book> AddBook(FileDialog dialog, ObservableCollection<Book> books)
        {
            IsSame = AddHelper(dialog, books);
            if (IsSame)
            {
               books.Add(new Book { NameBook = IntermediateResultNameBook, Path = InternadiateResultPathBook });

               return books;
            }

            return books;

        }

        public bool AddHelper(FileDialog dialog, ObservableCollection<Book> books)
        {
            dialog.GetFile(BookFilter, ref IntermediateResultNameBook, ref InternadiateResultPathBook);

            if (IntermediateResultNameBook != "No file selected" && InternadiateResultPathBook != "No file selected")
            {
                IsSame = !(books.Any(x => x.NameBook == IntermediateResultNameBook) && (books.Any(x => x.Path == InternadiateResultPathBook)));

                return IsSame;
            }

            return IsSame;
        }

        #endregion

        public override void FindViews(ICollectionView view, string searchValue)
        {
            view.Filter = (obj) =>
            {
                if (obj is Book book && !string.IsNullOrWhiteSpace(searchValue))
                {
                    return book.NameBook.ToLower().Contains(searchValue.ToLower());
                }

                if (string.IsNullOrWhiteSpace(searchValue))
                {
                    return true;
                }

                return false;
            };

            view.Refresh();
        }

    }
}
