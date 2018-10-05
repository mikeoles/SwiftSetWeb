using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSetWeb.Models
{
    public class ExerciseGroupViewModel {
        public IEnumerable<SortingGroup> SortingGroups { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }

    }
}
