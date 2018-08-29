using System;
using System.Collections.Generic;

namespace SwiftSetWeb.Models
{
    public partial class SortingCategory
    {
        public int Id { get; set; }
        public string SortBy { get; set; }
        public string ExerciseColumnName { get; set; }
        public string Name { get; set; }
    }
}
