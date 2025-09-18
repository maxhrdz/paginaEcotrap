using System.Numerics;

namespace NumericSeries.Models
{
    public sealed class TriangularSeries : INumericSeries{
        
        public string Key => "triangular";
        public string DisplayName => "Triangulares";
        public BigInteger ValueAt(int n) => (BigInteger)n * (n + 1) / 2; // 0,1,3,6,10,...
    }
}