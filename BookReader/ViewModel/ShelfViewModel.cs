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
            ListBook = Json.DeserializeShelfListBook(nameShelf);
            ListBook.NameShelf = nameShelf;
            ListBooksView = CollectionViewSource.GetDefaultView(ListBook.Books);
        }

        protected override void ModifyBooks()
        {
            ListBook.Books.Remove(SelectedBook);
            Json.Delete(ListBook.NameShelf, ListBook);
        }

        #region Add execute shelf view model    

        public override void AddExecute(object sender)
        {
            ListBook.Books = BookAction.AddBook(Dialog, ListBook.Books);
            Json.Serialize(ListBook.NameShelf, ListBook);
        }

        public override bool CanAddExecute(object sender) => true;
        #endregion

        public override void CloseExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new MainViewModel());
            base.CloseExecute(sender);
        }
    }
}
