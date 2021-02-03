using Microsoft.Win32;
using System;
using System.IO;

namespace BookReaderLibrary.Model.Dialogs
{
    public class FileDialog
    {
        public void GetFile(string format, ref string nameBook, ref string pathBook)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = format;
            switch (Dialog.ShowDialog())
            {
                case true:
                    nameBook = Path.GetFileName(Dialog.FileName);
                    pathBook = Dialog.FileName;
                    return;
            };

            nameBook = "No file selected";
            pathBook = "No file selected";
        }
    }
}
