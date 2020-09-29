using System;
using System.Collections.Generic;
using NameSorterApplication.Comperers;
using NameSorterApplication.Models;

namespace NameSorterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NameSorterObject> listObj = new List<NameSorterObject>();
           
            // dummy data and temp selection sort algo to test comparer class
            listObj.Add(new NameSorterObject { LastName = "Parsons", GivenNames = new List<string> { "Mou", "Had" } });
            listObj.Add(new NameSorterObject { LastName = "Parsons", GivenNames = new List<string> { "Mou" } });
            listObj.Add(new NameSorterObject { LastName = "Parsons", GivenNames = new List<string> { "Janet" } });
            listObj.Add(new NameSorterObject { LastName = "Lewis", GivenNames = new List<string> { "Vaughn" } });
            listObj.Add(new NameSorterObject { LastName = "Archer", GivenNames = new List<string> { "Adonis", "Julius" } });
            listObj.Add(new NameSorterObject { LastName = "Yoder", GivenNames = new List<string> { "Adonis", "Julius" } });
            listObj.Add(new NameSorterObject { LastName = "Alvarez", GivenNames = new List<string> { "Marin" } });



            NameSorterObject tempObject = new NameSorterObject();
            NameComparer nameComparer = new NameComparer();
            int indexOfMinValue = 0;
            for (int i = 0; i < listObj.Count - 1; i++)
            {
                indexOfMinValue = i;
                for (int j = i + 1; j < listObj.Count; j++)
                {
                    if (nameComparer.CompareTo(listObj[j], listObj[indexOfMinValue]) < 0)
                        indexOfMinValue = j;

                }

                tempObject = listObj[indexOfMinValue];
                listObj[indexOfMinValue] = listObj[i];
                listObj[i] = tempObject;
            }

            for (int i = 0; i < listObj.Count; i++)
            {
                for (int j = 0; j < listObj[i].NumberOfGivenName; j++)
                {
                    Console.Write(listObj[i].GivenNames[j] + " ");
                }
                Console.Write(listObj[i].LastName);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
