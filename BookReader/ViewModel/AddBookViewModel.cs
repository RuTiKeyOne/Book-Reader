using BookReader.ViewModel.Base;
using BookReaderLibrary.Model.Commands;
using BookReaderLibrary.Model.Dialogs;
using System;
using System.Windows;
using System.Windows.Input;

namespace BookReader.ViewModel
{
    public class AddBookViewModel : BaseAddViewModel
    {
        private FileDialog Dialog { get; set; }

        private string bookName = null;
        public string BookName
        {
            get => bookName;
            set => SetProperty(ref bookName, value);
        }


        public ICommand Select { get; set; }
        public void SelectExecute(object sender)
        {
            BookName = Dialog.GetFile((sender as string));
        }

        public bool CanSelectExecute(object sender) => true;

        public AddBookViewModel()
        {
            Dialog = new FileDialog();
            Select = new ActionCommand(SelectExecute, CanSelectExecute);
        }

        public override bool CanAddExecute(object sender) => !string.IsNullOrEmpty(BookName) && BookName != "No file selected";
    }
}
