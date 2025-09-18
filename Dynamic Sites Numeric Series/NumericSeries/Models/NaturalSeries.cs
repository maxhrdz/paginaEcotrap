using System.Numerics;

namespace NumericSeries.Models
{
    public sealed class NaturalSeries : INumericSeries
    {
        public string Key => "natural";
        public string DisplayName => "Naturales";
        public BigInteger ValueAt(int n) => n; // 0,1,2,3,...
    }
}