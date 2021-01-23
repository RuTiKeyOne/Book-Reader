using BookReaderLibrary.Model.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BookReaderLibrary.Model.Books
{
    public class Book
    {
        private string IntermediateResult { get; set; }
        private bool IsSame { get; set; }
        public void AddBook(FileDialog dialog, ref ObservableCollection<string> books, object sender)
        {
            IntermediateResult = dialog.GetFile((sender as string));

            if (IntermediateResult != "No file selected")
            {
                IsSame = books.Any(x => x == IntermediateResult);

                if (!IsSame)
                {
                    books.Add(IntermediateResult);
                }
            }

        }

    }
}
