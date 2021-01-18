using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;

namespace BookReader.ViewModel.Base
{
    public class BaseViewModel
    {
        public RelayCommand<Window> Close { get; set; }
        public void CloseWindow(Window window)
        {
            if(window != null)
            {
                window.Close();
            }
        }

        public RelayCommand<Window> Minimize { get; set; }
        public void MinimizeWindow(Window window)
        {
            if(window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        public BaseViewModel()
        {
            Close = new RelayCommand<Window>(this.CloseWindow);
            Minimize = new RelayCommand<Window>(this.MinimizeWindow);
        }
    }
}
