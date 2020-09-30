using NameSorterApplication.Comparers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorterApplication.Sorters
{
    public interface ISorter<TModel>
    {
        INameComparer<TModel> Comparer { get; }

        void Sort(List<TModel> targetArray);
    }
}
