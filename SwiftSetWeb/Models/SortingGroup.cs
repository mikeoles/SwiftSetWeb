using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSetWeb.Models
{
    public class SortingGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<SortingCategory> Categories { get; set; }
    }
}
