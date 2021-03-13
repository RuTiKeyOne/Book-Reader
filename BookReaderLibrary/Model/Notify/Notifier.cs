using System;

namespace BookReaderLibrary.Model.Notify
{
    public class Notifier
    {
        #region Events

        public event Action ModifySelectedItemEvent;

        #endregion

        #region Constructor

        public Notifier(Action ModifySelectedItemHandler)
        {
            ModifySelectedItemEvent += ModifySelectedItemHandler;
        }

        #endregion

        #region Methods

        public void ModifySelectedItem()
        {
            ModifySelectedItemEvent?.Invoke();
        }

        #endregion
    }
}
