using System.Numerics;

namespace NumericSeries.Models
{
    public interface INumericSeries
    {
        string Key { get; }
        string DisplayName { get; }
        BigInteger ValueAt(int n);
    }
}