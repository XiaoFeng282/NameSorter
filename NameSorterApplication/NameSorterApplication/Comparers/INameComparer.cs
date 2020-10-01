using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorterApplication.Comparers
{
    public interface INameComparer<TModel>
    {
        int Compare(TModel objectA, TModel objectB);
    }
}
