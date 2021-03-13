using System;

namespace BookReaderLibrary.Model.Patterns
{
    public class Singleton
    {
        #region Field and event

        private static Singleton _Singleton;
        public event Action<string> NotifierAddShelf;

        #endregion

        #region Constructor

        private Singleton() { }

        #endregion

        #region Methods

        public static Singleton GetInstance() { 
            if (_Singleton == null)
            {
                _Singleton = new Singleton();
            }

            return _Singleton;
        }

        public void NotifyAddShelfMainViewModel(string message)
        {
            NotifierAddShelf?.Invoke(message);        
        }

        #endregion

    }
}
