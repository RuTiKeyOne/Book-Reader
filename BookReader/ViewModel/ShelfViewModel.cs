using BookReader.ViewModel.Base;
using System;

namespace BookReader.ViewModel
{
    class ShelfViewModel : BaseViewModel
    {
        public override void CloseExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new MainViewModel());
            base.CloseExecute(sender);
        }

    }
}
