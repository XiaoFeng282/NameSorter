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
            List<NameSorterObject> result = new List<NameSorterObject>();

            using (FileStream fs = File.Open(TargetPathRead, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim().Length > 0)
                    {
                        result.Add(MapDataToNameSorterObject(line));
                    }
                }
            }
            return result;
        }

        public void WriteFile(List<NameSorterObject> objects)
        {
            using (FileStream fs = File.Open(TargetPathWrite, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter wr = new StreamWriter(bs))
            {
                foreach (NameSorterObject item in objects)
                {
                    wr.WriteLine(item.FullName);
                }
                wr.Flush();
            }

        }

        private static NameSorterObject MapDataToNameSorterObject(string data)
        {
            NameSorterObject result = new NameSorterObject();
            List<string> stringName;
            stringName = new List<string>(data.Split(" ", StringSplitOptions.RemoveEmptyEntries));
            if (stringName.Count > 0)
            {
                result.LastName = stringName[stringName.Count - 1];
                var a = stringName.Take(stringName.Count - 1).ToList();
                result.GivenNames.AddRange(stringName.Take(stringName.Count - 1).ToList());
            }

            return result;
        }
    }
}
