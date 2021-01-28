using BookReaderLibrary.Model.Base;
using BookReaderLibrary.Model.Shelfs;
using System;
using System.ComponentModel;

namespace BookReaderLibrary.Model.Actions
{
    public class ShelfAction : BaseAction
    {
        public override void FindViews(ICollectionView view, string searchValue)
        {
            view.Filter = (obj) =>
            {
                if (obj is Shelf shelf)
                {
                    return shelf.ShelfName.ToLower().Contains(searchValue.ToLower());
                }

                return false;
            };

            view.Refresh();
        }
    }
}
