using System;

namespace BookReaderLibrary.Model.Patterns
{
    public class Singleton
    {
        private static Singleton _Singleton;
        public event Action<string> NotifierAddShelf;


        private Singleton() { }


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

    }
}
