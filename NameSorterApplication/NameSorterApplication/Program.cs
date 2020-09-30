using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NameSorterApplication.Comperers;
using NameSorterApplication.Helpers;
using NameSorterApplication.Models;
using NameSorterApplication.Sorters;

namespace NameSorterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ISorter<NameSorterObject> sorter = new NameSorter(new NameComparer());
            IFileHelper<NameSorterObject> fileHelper = new NameSorterFileHelper("unsorted-names-list.txt", "sorted-names-list.txt");
            List<NameSorterObject> listObj = fileHelper.ReadFile();

            sorter.Sort(listObj);

            fileHelper.WriteFile(listObj);

            foreach (var item in listObj)
            {
                Console.WriteLine(item.FullName);
            }

            Console.ReadLine();
        }
    }
}
