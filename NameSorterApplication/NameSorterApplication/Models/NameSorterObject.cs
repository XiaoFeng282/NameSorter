using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorterApplication.Models
{
    class NameSorterObject
    {
        public NameSorterObject()
        {
            GivenNames = new List<string>();
        }

        public string LastName { get; set; }
        public List<string> GivenNames { get; set; }

        public int NumberOfGivenName
        {
            get { return GivenNames.Count; }
        }
    }
}
