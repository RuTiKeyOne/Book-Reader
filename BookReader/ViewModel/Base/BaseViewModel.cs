using BookReaderLibrary.Model.Commands;
using BookReaderLibrary.Model.Windows;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;

namespace BookReader.ViewModel.Base
{
    public class BaseViewModel
    {
        public DisplayRootRegistry DisplayRootRegistry {get; private set; }

        #region Close Command

        public ICommand Close { get; set; }
        public virtual bool CanCloseExecute(object sender) => true;
        public void CloseExecute(object sender) 
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
            Close = new ActionCommand(CloseExecute, CanCloseExecute);
            Minimize = new RelayCommand<Window>(this.MinimizeWindow);
            DisplayRootRegistry = (Application.Current as App).DisplayRootRegistry;
        }
    }
}
