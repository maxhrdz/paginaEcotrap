using System.Collections.Generic;
using System.Numerics;

namespace NumericSeries.Models
{
    public class SeriesViewModel
    {
        
        public string SerieKey { get; set; } = "";
        public string SerieName { get; set; } = "";
        public int N { get; set; }
        public BigInteger Value { get; set; } 

        public string? PrevUrl { get; set; }
        public string NextUrl { get; set; } = "";

        
        public IReadOnlyList<INumericSeries> NavSeries { get; set; } = new List<INumericSeries>();


    }
}