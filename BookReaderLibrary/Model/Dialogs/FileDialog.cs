using Microsoft.Win32;
using System;

namespace BookReaderLibrary.Model.Dialogs
{
    public class FileDialog
    {
        public string GetFile(string format)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = format;
            switch (Dialog.ShowDialog())
            {
                case true:
                    return Dialog.FileName;
            };
            return "No file selected";
        }
    }
}
