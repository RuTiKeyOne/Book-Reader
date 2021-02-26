using BookReaderLibrary.Model.Books;
using BookReaderLibrary.Model.BooksAction;
using BookReaderLibrary.Model.Commands;
using BookReaderLibrary.Model.Dialogs;
using BookReaderLibrary.Model.Json;
using BookReaderLibrary.Model.Patterns;
using BookReaderLibrary.Model.Windows;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
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
        protected Action<string> MainViewModelHandler { get; set; }
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

        protected Book selectedBook;
        public virtual Book SelectedBook { get; set; }

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

    }
}
