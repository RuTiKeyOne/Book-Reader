using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Lists;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace BookReader.ViewModel
{
    class ShelfViewModel : AddShelfViewModel
    {
        private string nameOpenedShelf;
        public string NameOpenedShelf
        {
            get => nameOpenedShelf;
            set => SetProperty(ref nameOpenedShelf, value);
        }



        private ShelfListBook book;
        public ShelfListBook Books
        {
            get => book;
            set => SetProperty(ref book, value);
        }

        public ICollectionView ListBooks { get; set; }

        public ShelfViewModel(){}

        public ShelfViewModel(string nameShelf)
        {
            ListBooks = CollectionViewSource.GetDefaultView(Books);
            NameOpenedShelf = nameShelf;
        }

        #region Add execute shelf view model
        public override void AddExecute(object sender)
        {
            
        }

        public override bool CanAddExecute(object sender) => true;
        #endregion

    }
}
