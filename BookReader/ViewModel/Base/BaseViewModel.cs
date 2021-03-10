using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.BooksAction;
using BookReaderLibrary.Model.Commands;
using BookReaderLibrary.Model.Dialogs;
using BookReaderLibrary.Model.Json;
using BookReaderLibrary.Model.Notify;
using BookReaderLibrary.Model.Patterns;
using BookReaderLibrary.Model.Shelves;
using BookReaderLibrary.Model.Windows;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace BookReader.ViewModel.Base
{
    public enum SelectionMode
    {
        Selection,
        Removal
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        private Shelf IntermediateSelectedShelf { get; set; }

        #region Shelfves view 

        private Shelf selectedShelf;
        public Shelf SelectedShelf
        {
            get => selectedShelf;
            set
            {
                SetProperty(ref selectedShelf, value);

                switch (Mode)
                {
                    case SelectionMode.Selection when (!(selectedShelf is null)):
                        DisplayRootRegistry.ShowPresentation(new ShelfViewModel(SelectedShelf.ShelfName));
                        DisplayRootRegistry.HidePresentation(this);
                        break;
                    case SelectionMode.Removal:
                        DisplayRootRegistry.ShowPresentation(new DeleteMessageShowingViewModel(ModifyShelf, RezeroShelf));
                        Mode = SelectionMode.Selection;
                        break;
                }
            }
        }

        public ICollectionView ShelfsView { get; set; }

        protected ObservableCollection<Shelf> shelves;

        public ObservableCollection<Shelf> Shelves
        {
            get => shelves;
            set => SetProperty(ref shelves, value);
        }

        #endregion

        #region Books view

        public ICollectionView BooksView { get; set; }

        protected ObservableCollection<Book> books;

        public ObservableCollection<Book> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }

        #endregion
        protected CustomJson Json { get; set; }
        protected FileDialog Dialog { get; set; }
        protected BookAction BookAction { get; set; }
        protected DisplayRootRegistry DisplayRootRegistry {get; private set; }

        protected Singleton Singleton { get; set; }
        
        #region Close Command

        public ICommand Close { get; set; }

        public bool CanCloseExecute(object sender) => true;
        public virtual void CloseExecute(object sender) 
        {
            DisplayRootRegistry.HidePresentation(this);
        }

        #endregion

        #region Minimize Command
        public RelayCommand<Window> Minimize { get; set; }
        public void MinimizeWindow(Window window)
        {
            if(window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        #endregion

        public BaseViewModel()
        {
            Singleton = Singleton.GetInstance();
            Close = new ActionCommand(CloseExecute, CanCloseExecute);
            Minimize = new RelayCommand<Window>(this.MinimizeWindow);
            DisplayRootRegistry = (Application.Current as App).DisplayRootRegistry;
            BookAction = new BookAction();
            Dialog = new FileDialog();

            Json = new CustomJson();

        }

        #region Interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        private Book selectedBook;
        public Book SelectedBook
        {
            get
            {
                return selectedBook;
            }

            set
            {
                SetProperty(ref selectedBook, value);

                switch (Mode)
                {
                    case SelectionMode.Selection when !(SelectedBook is null):
                        ShowPdfReaderHelper(SelectedBook.Path);
                        DisplayRootRegistry.HidePresentation(this);
                        break;
                    case SelectionMode.Removal:
                        DisplayRootRegistry.ShowPresentation(new DeleteMessageShowingViewModel(ModifyBooks, RezeroBook));
                        Mode = SelectionMode.Selection;
                        break;
                }

            }
        }


        protected SelectionMode Mode { get; set; }



        public void ShowPdfReaderHelper(string path)
        {
            if (File.Exists(path))
            {
                DisplayRootRegistry.ShowPresentation(new PdfReaderViewModel(SelectedBook.Path));
            }
            else
            {
                DisplayRootRegistry.ShowPresentation(new MessageShowingViewModel("File not found"));
            }
        }

        private void ModifyBooks()
        {
            Books.Remove(SelectedBook);
            Json.Delete(Books); 
        }

        private void ModifyShelf()
        {
            IntermediateSelectedShelf = SelectedShelf;
            Shelves.Remove(SelectedShelf);
            Json.Delete(Shelves, IntermediateSelectedShelf);
            IntermediateSelectedShelf = null;
        }

        private void RezeroBook()
        {
            SelectedBook = null;
        }

        private void RezeroShelf()
        {
            SelectedShelf = null;
        }
    }
}
