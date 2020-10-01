using NameSorterApplication.Comparers;
using NameSorterApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorterApplication.Sorters
{
    public class NameSorter : ISorter<NameSorterObject>
    {
        INameComparer<NameSorterObject> comparer;

        public INameComparer<NameSorterObject> Comparer => comparer;

        public NameSorter(INameComparer<NameSorterObject> comparer)
        {
            this.comparer = comparer;
        }

        public void Sort(List<NameSorterObject> targetArray)
        {
            if (targetArray == null)
            {
                throw new ArgumentNullException("Invalid array.");
            }

            if (targetArray.Count <= 1)
            {
                return;
            }

            Devide(targetArray, 0, targetArray.Count - 1);
        }

        public void Devide(List<NameSorterObject> arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int mid = (leftIndex + rightIndex) / 2;
                Devide(arr, leftIndex, mid);
                Devide(arr, mid + 1, rightIndex);
                Merge(arr, leftIndex, mid, rightIndex);
            }
        }

        public void Merge(List<NameSorterObject> arr, int leftIndex, int middle, int rightIndex)
        {
            int numberOfLeftArray = middle - leftIndex + 1; 
            int numberOfRightArray = rightIndex - middle;   
            List<NameSorterObject> leftArray = new List<NameSorterObject>(numberOfLeftArray);
            List<NameSorterObject> rightArray = new List<NameSorterObject>(numberOfRightArray);
            int i = 0, j = 0;

            for (i = 0; i < numberOfLeftArray; i++)   
                leftArray.Add(arr[leftIndex + i]);

            for (j = 0; j < numberOfRightArray; j++)   
                rightArray.Add(arr[middle + 1 + j]);

            i = 0;
            j = 0;
            int k;
            for (k = leftIndex; i < numberOfLeftArray && j < numberOfRightArray; k++)
            {
                if (Comparer.Compare(leftArray[i], rightArray[j]) <= 0) 
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
            }

            while (i < numberOfLeftArray)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < numberOfRightArray)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}
