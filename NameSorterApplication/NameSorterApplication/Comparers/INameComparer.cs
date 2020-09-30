using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorterApplication.Comparers
{
    public interface INameComparer<TModel>
    {
        int CompareTo(TModel objectA, TModel objectB);
    }
}
