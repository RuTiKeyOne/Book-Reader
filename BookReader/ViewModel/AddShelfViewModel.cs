using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Patterns;

namespace BookReader.ViewModel
{
    public class AddShelfViewModel : BaseAddViewModel
    {
        #region Fields

        private string nameShelf = null;

        #endregion

        #region Properties

        public string NameShelf
        {
            get => nameShelf;
            set => SetProperty(ref nameShelf, value);
        }

        #endregion

        #region Methods

        public override bool CanAddExecute(object sender) => !string.IsNullOrEmpty(NameShelf);

        public override void AddExecute(object sender)
        {
            Singleton.NotifyAddShelfMainViewModel(nameShelf);

            DisplayRootRegistry.HidePresentation(this);
        }

        #endregion
    }
}
