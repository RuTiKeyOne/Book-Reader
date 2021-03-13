using BookReader.ViewModel.Base;

namespace BookReader.ViewModel
{
    public class MessageShowingViewModel : BaseViewModel
    {
        #region Fields

        private string message = null;

        #endregion

        #region Properties

        public string Message
        {
            get => message;
            set
            {
                SetProperty(ref message, value);
            }
        }

        #endregion

        #region Constructor

        public MessageShowingViewModel() { }
        public MessageShowingViewModel(string message)
        {
            Message = message;
        }

        #endregion 
    }
}
