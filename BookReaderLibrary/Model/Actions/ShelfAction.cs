using BookReaderLibrary.Model.Base;
using BookReaderLibrary.Model.Shelfs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace BookReaderLibrary.Model.Actions
{
    public class ShelfAction : BaseAction
    {
        public override void AddShelf(string nameShelf, ref ObservableCollection<Shelf> shelfs)
        {
            if (!string.IsNullOrEmpty(nameShelf))
            {
                IsSame = shelfs.Any(x => x.ShelfName == nameShelf);

                if (!IsSame)
                {
                    shelfs.Add(new Shelf { ShelfName = nameShelf });

                }
            }
        }


        public override void FindViews(ICollectionView view, string searchValue)
        {
                view.Filter = (obj) =>
                {
                if (obj is Shelf shelf && !string.IsNullOrWhiteSpace(searchValue))
                {
                  return shelf.ShelfName.ToLower().Contains(searchValue.ToLower());
                }

                if (string.IsNullOrWhiteSpace(searchValue))
                {
                   return true;
                }

                    return false;
                };

                view.Refresh();
        }

    }
}
