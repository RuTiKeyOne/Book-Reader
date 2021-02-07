using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Patterns;
using System;
using System.Windows;

namespace BookReader.ViewModel
{
    public class AddShelfViewModel : BaseAddViewModel
    {
        private string nameShelf = null;
        public string NameShelf
        {
            get => nameShelf;
            set => SetProperty(ref nameShelf, value);
        }

        public override bool CanAddExecute(object sender) => !string.IsNullOrEmpty(NameShelf);

        public override void AddExecute(object sender)
        {
            Singleton.NotifyAddShelfMainViewModel(nameShelf);

            DisplayRootRegistry.HidePresentation(this);
        }
    }
}
