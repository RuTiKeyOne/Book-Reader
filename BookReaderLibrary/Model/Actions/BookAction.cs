using BookReaderLibrary.Model.Base;
using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BookReaderLibrary.Model.BooksAction
{
    public class BookAction : BaseAction
    {
        private string IntermediateResult { get; set; }
        private bool IsSame { get; set; }
        public void AddBook(FileDialog dialog, ref ObservableCollection<Book> books, object sender)
        {
            IntermediateResult = dialog.GetFile((sender as string));

            if (IntermediateResult != "No file selected")
            {
                IsSame = books.Any(x => x.NameBook == IntermediateResult);

                if (!IsSame)
                {
                    books.Add(new Book {NameBook = IntermediateResult });
                }
            }

        }

        public override void FindViews(ICollectionView view, string searchValue)
        {
            view.Filter = (obj) =>
            {
                if (obj is Book book)
                {
                    return book.NameBook.ToLower().Contains(searchValue.ToLower());
                }

                return false;
            };

            view.Refresh();
        }
    }
}
