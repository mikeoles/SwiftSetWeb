using System;
using System.Collections.Generic;

namespace SwiftSetWeb.Models
{
    public partial class Exercises
    {
        public int Id { get; set; }
        public int? Eliminated { get; set; }
        public string Name { get; set; }
        public int? Difficulty { get; set; }
        public string Primary { get; set; }
        public string Equipment { get; set; }
        public string Movement { get; set; }
        public string Angle { get; set; }
        public string Tempo { get; set; }
        public int? Unilateral { get; set; }
        public string Joint { get; set; }
        public int? Stability { get; set; }
        public string Sport { get; set; }
        public string Grip { get; set; }
        public string Url { get; set; }
    }
}
