using BookReader.ViewModel.Base;

namespace BookReader.ViewModel
{
    public class PdfReaderViewModel : BaseViewModel
    {
        #region Fields 

        private string sourceBook = null;

        #endregion

        #region Properties

        public string SourceBook
        {
            get => sourceBook;
            set => SetProperty(ref sourceBook, value);
        }

        #endregion

        #region Constructor

        public PdfReaderViewModel(){}
        public PdfReaderViewModel(string path)
        {
            SourceBook = path;
        }

        #endregion

        #region Methods 

        public override void CloseExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new MainViewModel());
            base.CloseExecute(sender);
        }

        #endregion

    }
}
