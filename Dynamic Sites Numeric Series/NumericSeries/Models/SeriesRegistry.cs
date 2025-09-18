using System.Collections.Generic;
using System.Linq;

namespace NumericSeries.Models
{
    public static class SeriesRegistry
    {
        //  series soportadas
        private static readonly INumericSeries[] _all = new INumericSeries[]
        {
            new NaturalSeries(),
            new FibonacciSeries(),
            new SquaresSeries(),
            new CubesSeries(),
            new TriangularSeries(),
        };

        public static IReadOnlyList<INumericSeries> All => _all;

        public static INumericSeries? Get(string? key) =>
            _all.FirstOrDefault(s => s.Key.Equals(key ?? "", System.StringComparison.OrdinalIgnoreCase));
    }
}