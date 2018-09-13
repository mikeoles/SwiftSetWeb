using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSetWeb.Models
{
    public class SortingGroup
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IList<SortingCategory> Categories { get; set; }
        public string ExerciseColumnName { get; set; }
        public Boolean IsOriginal { get; set; }
        public Boolean IsMultiChoice { get; set; }
        public ICollection<NewOption> Follows { get; set; }
    }
}
