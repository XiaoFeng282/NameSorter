using System;
using System.Collections.Generic;
using System.Text;
using NameSorterApplication.Models;

namespace NameSorterApplication.Comperers
{
    interface INameComparer
    {
        public int CompareTo(NameSorterObject objectA, NameSorterObject objectB);
    }

    class NameComparer : INameComparer
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

            // in case lastname are the same then compare given name
            int maximumNumberToLoop = 0;

            if (objectA.NumberOfGivenName > objectB.NumberOfGivenName)
            {
                maximumNumberToLoop = objectB.NumberOfGivenName;
            }
            else if (objectA.NumberOfGivenName < objectB.NumberOfGivenName)
            {
                maximumNumberToLoop = objectA.NumberOfGivenName;
            }
            else
            {
                maximumNumberToLoop = objectA.NumberOfGivenName;
            }

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

                // in case arr reached to the end of the loop that means they have all  the same first and given name
                // continue to compare the length the smaller one will be 
                if (i == maximumNumberToLoop - 1)
                {
                    if (objectA.NumberOfGivenName > objectB.NumberOfGivenName)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }
}
