using System.Numerics;

namespace NumericSeries.Models
{
    public sealed class SquaresSeries : INumericSeries
    {
        public string Key => "cuadrados";
        public string DisplayName => "Cuadrados";
        public BigInteger ValueAt(int n) => (BigInteger)n * n; // 0,1,4,9,16,...
    }
}