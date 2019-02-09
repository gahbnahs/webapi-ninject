using System;

namespace countingksps.Models
{
    public interface IDiary
    {
        DateTime date { get; set; }
        string url { get; set; }
    }
}