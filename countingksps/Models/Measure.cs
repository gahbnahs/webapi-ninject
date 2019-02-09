using System;

namespace countingksps.Models
{
    public class Measure
    {
        public string url { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal TotalFat { get; set; }
        public virtual Food Food { get; set; }
    }
}