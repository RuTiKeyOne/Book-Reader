using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderLibrary.Model.Base
{
    public abstract class BaseAction
    {
        public abstract void FindViews(ICollectionView view, string searchValue);
    }
}
