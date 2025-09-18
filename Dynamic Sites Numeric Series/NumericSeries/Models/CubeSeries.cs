using System.Numerics;

namespace NumericSeries.Models
{
    public sealed class CubesSeries : INumericSeries
    {
        public string Key => "cubos";
        public string DisplayName => "Cubos";
        public BigInteger ValueAt(int n) => (BigInteger)n * n * n; // 0,1,8,27,...
    }
}