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
        private string IntermediateResult { get; set; }
        public override void AddBook(FileDialog dialog, ref ObservableCollection<Book> books, object sender)
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
