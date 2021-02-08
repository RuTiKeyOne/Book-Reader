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
        private ShelfListBook book;
        public ShelfListBook Books
        {
            get => book;
            set => SetProperty(ref book, value);
        }

        public ICollectionView ListBooks { get; set; }

        public override void CloseExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new MainViewModel());
            base.CloseExecute(sender);
        }

        public ShelfViewModel()
        {
            ListBooks = CollectionViewSource.GetDefaultView(Books);
        }

        #region Add execute shelf view model
        public override void AddExecute(object sender)
        {

        }

        public override bool CanAddExecute(object sender) => true;
        #endregion

    }
}
