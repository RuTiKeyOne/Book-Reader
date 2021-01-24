using Microsoft.Win32;
using System;
using System.IO;

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
                    return Path.GetFileName(Dialog.FileName);
            };
            return "No file selected";
        }
    }
}
