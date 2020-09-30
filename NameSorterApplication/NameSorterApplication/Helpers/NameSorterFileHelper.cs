using NameSorterApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NameSorterApplication.Helpers
{
    public class NameSorterFileHelper : IFileHelper<NameSorterObject>
    {
        public string TargetPathRead { get; set; }

        public string TargetPathWrite { get; set; }

        public NameSorterFileHelper(string targetPathRead, string targetPathWrite)
        {
            TargetPathRead = targetPathRead ?? throw new ArgumentNullException(nameof(targetPathRead));
            TargetPathWrite = targetPathWrite ?? throw new ArgumentNullException(nameof(targetPathWrite));
        }

        public List<NameSorterObject> ReadFile()
        {
            string file = TargetPathRead;
            string nameString = "";
            List<NameSorterObject> nameSorterObject = new List<NameSorterObject>();
            if (File.Exists(file))
            {
                using (StreamReader streamReader = new StreamReader(file))
                {
                    nameString = File.ReadAllText(file);
                }
            }
            if (!string.IsNullOrEmpty(nameString))
            {
                nameSorterObject = MapDataToNameSorterObject(nameString);
            }
            return nameSorterObject;
        }

        public void WriteFile(List<NameSorterObject> objects)
        {
            string path = TargetPathWrite;
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var item in objects)
                    {
                        sw.Write(String.Join(" ", item.GivenNames.ToArray()));
                        sw.WriteLine($" {item.LastName}");
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var item in objects)
                    {
                        sw.Write(String.Join(" ", item.GivenNames.ToArray()));
                        sw.WriteLine($" {item.LastName}");
                    }
                }
            }
        }

        private static List<NameSorterObject> MapDataToNameSorterObject(string data)
        {
            List<NameSorterObject> result = new List<NameSorterObject>();

            string separator = "\r\n";
            List<string> listStringNames = new List<string>(data.Split(separator, StringSplitOptions.RemoveEmptyEntries));
            List<string> stringName;
            NameSorterObject tempObject = new NameSorterObject();
            foreach (var item in listStringNames)
            {
                stringName = new List<string>(item.Split(" ", StringSplitOptions.RemoveEmptyEntries));
                if (stringName.Count > 0)
                {
                    tempObject.LastName = stringName[stringName.Count - 1];
                    var a = stringName.Take(stringName.Count - 1).ToList();
                    tempObject.GivenNames.AddRange(stringName.Take(stringName.Count - 1).ToList());
                }
                result.Add(tempObject);
                tempObject = new NameSorterObject();
            }

            return result;
        }
    }
}
