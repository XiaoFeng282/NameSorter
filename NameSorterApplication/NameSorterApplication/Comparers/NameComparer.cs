using System;
using System.Collections.Generic;
using System.Text;
using NameSorterApplication.Comparers;
using NameSorterApplication.Models;

namespace NameSorterApplication.Comperers
{
    public class NameComparer : INameComparer<NameSorterObject>
    {
        public int CompareTo(NameSorterObject objectA, NameSorterObject objectB)
        {
            if (objectA.LastName.CompareTo(objectB.LastName) > 0)
            {
                return 1;
            }
            else if (objectA.LastName.CompareTo(objectB.LastName) < 0)
            {
                return -1;
            }

            int maximumNumberToLoop = Math.Min(objectA.NumberOfGivenName, objectB.NumberOfGivenName);

            for (int i = 0; i < maximumNumberToLoop; i++)
            {
                if (objectA.GivenNames[i].CompareTo(objectB.GivenNames[i]) > 0)
                {
                    return 1;
                }
                else if (objectA.GivenNames[i].CompareTo(objectB.GivenNames[i]) < 0)
                {
                    return -1;
                }
                
            }

            if (objectA.NumberOfGivenName > objectB.NumberOfGivenName)
            {
                return 1;
            }
            else if(objectA.NumberOfGivenName < objectB.NumberOfGivenName)
            {
                return -1;
            }

            return 0;
        }
    }
}
