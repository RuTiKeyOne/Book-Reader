using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.Lists;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace BookReader.ViewModel
{
    class ShelfViewModel : AddShelfViewModel
    {
        public ShelfListBook ListBook { get; set; }

        public ICollectionView ListBooksView { get; set; }

        public ShelfViewModel(){}

        public ShelfViewModel(string nameShelf)
        {
            ListBook = new ShelfListBook();
            ListBook.NameShelf = nameShelf;
            ListBooksView = CollectionViewSource.GetDefaultView(ListBook.Books);
        }

        #region Add execute shelf view model    

        public override void AddExecute(object sender)
        {
            ListBook.Books = BookAction.AddBook(Dialog, ListBook.Books);
            Json.Serialize(ListBook);
        }

        public override bool CanAddExecute(object sender) => true;
        #endregion
    }
}
