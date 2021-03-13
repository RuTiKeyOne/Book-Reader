using System;

namespace BookReaderLibrary.Model.Notify
{
    public class Notifier
    {
        public event Action ModifySelectedItemEvent;


        public Notifier(Action ModifySelectedItemHandler)
        {
            ModifySelectedItemEvent += ModifySelectedItemHandler;
        }


        public void ModifySelectedItem()
        {
            ModifySelectedItemEvent?.Invoke();
        }

    }
}
