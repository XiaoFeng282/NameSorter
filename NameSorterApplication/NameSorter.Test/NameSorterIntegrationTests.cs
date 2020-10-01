using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorterApplication.Comperers;
using NameSorterApplication.Helpers;
using NameSorterApplication.Models;
using NameSorterApplication.Sorters;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Test
{
    [TestClass]
    public class NameSorterIntegrationTests
    {
        private void SortedResult(NameSorterObject[] arr)
        {
            Array.Sort(arr, new FakeComparer());
        }

        private NameSorterObject[] ExpectedResultOfTenElements;

        public NameSorterIntegrationTests()
        {
            IFileHelper<NameSorterObject> fileHelper = new NameSorterFileHelper("unsorted-names-list.txt", "sorted-names-list.txt");
            List<NameSorterObject> listObj = fileHelper.ReadFile();
            NameSorterObject[] arr = listObj.ToArray();
            SortedResult(arr);
            ExpectedResultOfTenElements = arr;
        }

        [TestMethod]
        public void GivenListOfObjectHasFiveHundredThousand_ShouldOrderByASC()
        {
            ISorter<NameSorterObject> sorter = new NameSorterApplication.Sorters.NameSorter(new NameComparer());
            IFileHelper<NameSorterObject> fileHelper = new NameSorterFileHelper("unsorted-names-list.txt", "sorted-names-list.txt");
            List<NameSorterObject> listObj = fileHelper.ReadFile();

            sorter.Sort(listObj);

            fileHelper.WriteFile(listObj);

            for (int i = 0; i < listObj.Count; i++)
            {
                Assert.AreEqual(ExpectedResultOfTenElements[i].FullName, listObj[i].FullName);
            }
        }
    }
}
