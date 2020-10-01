using NameSorterApplication.Comperers;
using NameSorterApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NameSorter.Test
{
    public class FakeComparer : IComparer<NameSorterObject>
    {
        public int Compare([AllowNull] NameSorterObject objectA, [AllowNull] NameSorterObject objectB)
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
            else if (objectA.NumberOfGivenName < objectB.NumberOfGivenName)
            {
                return -1;
            }

            return 0;
        }
    }
}
