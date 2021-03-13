using BookReaderLibrary.Model.Base;
using BookReaderLibrary.Model.Dialogs;
using BookReaderLibrary.Model.Shelves;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BookReaderLibrary.Model.Actions
{
    public class ShelfAction : BaseAction
    {
        #region Add

        public override void AddShelf(string nameShelf, ref ObservableCollection<Shelf> shelfs, FileDialog dialog)
        {
            if (!string.IsNullOrEmpty(nameShelf) && !(shelfs.Any(x => x.ShelfName == nameShelf)))
            {
               shelfs.Add(new Shelf { ShelfName = nameShelf });
            }
        }
        
        public bool AddHelper(FileDialog dialog, ObservableCollection<Shelf> books)
        {
            dialog.GetFile(BookFilter, ref IntermediateResultNameBook, ref InternadiateResultPathBook);

            if (IntermediateResultNameBook != "No file selected" && InternadiateResultPathBook != "No file selected")
            {
                IsSame = !(books.Any(x => x.ShelfName == IntermediateResultNameBook));

                return IsSame;
            }

            return IsSame;
        }

        #endregion

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
