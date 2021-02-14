using BookReader.ViewModel.Base;
using System;

namespace BookReader.ViewModel
{
    public class MessageShowingViewModel : BaseViewModel
    {
        private string message = null;
        public string Message
        {
            get => message;
            set
            {
                SetProperty(ref message, value);
            }
        }

        public MessageShowingViewModel() { }
        public MessageShowingViewModel(string message)
        {
            Message = message;
        }
    }
}
