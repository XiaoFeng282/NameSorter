using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorterApplication.Helpers
{
    public interface IFileHelper<TMapper>
    {
        string TargetPathRead { get; set; }

        string TargetPathWrite { get; set; }

        List<TMapper> ReadFile();

        void WriteFile(List<TMapper> objects);
    }
}
