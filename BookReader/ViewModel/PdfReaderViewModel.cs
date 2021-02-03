using BookReader.ViewModel.Base;
using System;

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
    }
}
