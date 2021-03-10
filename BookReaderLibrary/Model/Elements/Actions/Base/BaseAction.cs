using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.Dialogs;
using BookReaderLibrary.Model.Shelves;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderLibrary.Model.Base
{
    public abstract class BaseAction
    {
        protected string BookFilter { get; set; } = "Book file|*.pdf";
        protected string IntermediateResultNameBook = default;
        protected string InternadiateResultPathBook = default;

        protected bool IsSame { get; set; }

        public virtual void AddBook(FileDialog dialog, ref ObservableCollection<Book> books) { }
        public virtual ObservableCollection<Book> AddBook(FileDialog dialog, ObservableCollection<Book> books) => null;
        public virtual void AddShelf(string nameShelf, ref ObservableCollection<Shelf> shelfs, FileDialog dialog) { }
        public abstract void FindViews(ICollectionView view, string searchValue);
    }
}
