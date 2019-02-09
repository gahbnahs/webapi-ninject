using System.Collections.Generic;

namespace countingksps.Models
{
    public class Food
    {
        public string url { get; set; }
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<Measure> Measures { get; set; }
    }
}