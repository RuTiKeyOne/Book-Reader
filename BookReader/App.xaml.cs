using BookReader.ViewModel;
using System.Windows;
using BookReaderLibrary.Model.Windows;
using BookReader.View;
using System;

namespace BookReader
{
    public partial class App : Application
    {
        internal MainViewModel MainViewModel { get; set; }
        public DisplayRootRegistry DisplayRootRegistry { get; set; }
        
        public App()
        {
            DisplayRootRegistry = new DisplayRootRegistry();
            MainViewModel = new MainViewModel();
            DisplayRootRegistry.RegistryWindowType<MainViewModel, MainWindow>();
            DisplayRootRegistry.RegistryWindowType<AddShelfViewModel, AddShelfWindow>();
            DisplayRootRegistry.RegistryWindowType<PdfReaderViewModel, PdfReaderWindow>();
            DisplayRootRegistry.RegistryWindowType<ShelfViewModel, ShelfWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await DisplayRootRegistry.ShowModalPresendation(MainViewModel);
        }
    }
}
