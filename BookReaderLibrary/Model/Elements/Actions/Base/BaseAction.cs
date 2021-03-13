using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.Dialogs;
using BookReaderLibrary.Model.Shelves;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BookReaderLibrary.Model.Base
{
    public abstract class BaseAction
    {
        protected string BookFilter { get; set; } = "Book file|*.pdf";
        protected bool IsSame { get; set; }

        protected string IntermediateResultNameBook = default;
        protected string InternadiateResultPathBook = default;


        #region Add

        public virtual void AddBook(FileDialog dialog, ref ObservableCollection<Book> books) { }
        public virtual ObservableCollection<Book> AddBook(FileDialog dialog, ObservableCollection<Book> books) => null;

        #endregion

        public virtual void AddShelf(string nameShelf, ref ObservableCollection<Shelf> shelfs, FileDialog dialog) { }
        public abstract void FindViews(ICollectionView view, string searchValue);

    }
}
