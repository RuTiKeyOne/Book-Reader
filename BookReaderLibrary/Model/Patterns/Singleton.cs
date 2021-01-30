using System;
using System.Collections.Generic;
using System.Text;

namespace BookReaderLibrary.Model.Patterns
{
    //Меня терзают смутные сомнения 
    public class Singleton
    {
        private Singleton() { }

        private static Singleton _Singleton;
        public event Action<string> Notifier;

        public static Singleton GetInstance() { 
            if (_Singleton == null)
            {
                _Singleton = new Singleton();
            }

            return _Singleton;
        }



        public void NotifyMainViewModel(string message)
        {
            Notifier?.Invoke(message);
        }
    }
}
