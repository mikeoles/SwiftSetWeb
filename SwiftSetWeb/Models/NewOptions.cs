using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSetWeb.Models
{
    public class NewOptions
    {
        public int SortingGroupId { get; set; }
        public int SortingCategoryId { get; set; }
        public SortingCategory SortingCategory { get; set; }
        public SortingGroup SortingGroup { get; set; }
    }
}
