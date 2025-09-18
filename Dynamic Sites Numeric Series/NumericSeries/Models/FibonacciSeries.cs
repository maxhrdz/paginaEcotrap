using System.Numerics;

namespace NumericSeries.Models
{
    public sealed class FibonacciSeries : INumericSeries
    {
        public string Key => "fibonacci";
        public string DisplayName => "Fibonacci";

        // O(n) sin recurion
        public BigInteger ValueAt(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            BigInteger a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                var next = a + b;
                a = b;
                b = next;
            }
            return b;
        }
    }
}