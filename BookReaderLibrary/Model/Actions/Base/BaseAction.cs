using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.Dialogs;
using BookReaderLibrary.Model.Shelfs;
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
        protected bool IsSame { get; set; }

        public virtual void AddBook(FileDialog dialog, ref ObservableCollection<Book> books, object sender) { }
        public virtual void AddShelf(string nameShelf, ref ObservableCollection<Shelf> shelfs) { }
        public abstract void FindViews(ICollectionView view, string searchValue);
    }
}
