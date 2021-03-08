using BookReader.ViewModel.Base;
using System;
using System.Windows;

namespace BookReader.ViewModel
{
    public class PdfReaderViewModel : BaseViewModel
    {
        private string sourceBook = null;
        public string SourceBook
        {
            get => sourceBook;
            set => SetProperty(ref sourceBook, value);
        }

        public PdfReaderViewModel(){}
        public PdfReaderViewModel(string path)
        {
            SourceBook = path;
        }

        public override void CloseExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new MainViewModel());
            base.CloseExecute(sender);
        }

    }
}
