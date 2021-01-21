using BookReader.ViewModel.Base;
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
    }
}
