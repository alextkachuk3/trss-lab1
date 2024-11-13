namespace trss_lab1
{
    public class Bernoulli
    {
        private static List<Fraction> _cache = [new Fraction(1, 1)];

        public static Fraction Evaluate(int n)
        {
            if (n < 0)
                throw new ArgumentException("The index of Bernoulli number cannot be negative.");

            if (n % 2 != 0 && n > 1)
                return new Fraction(0, 1);

            if (n < _cache.Count)
                return _cache[n];

            for (int m = _cache.Count; m <= n; m++)
            {
                Fraction totalSum = new Fraction(0, 1);

                for (int k = 0; k < m; k++)
                {
                    var binomial = Utility.BinomialCoefficient(m + 1, k);
                    totalSum += binomial * _cache[k];
                }

                Fraction b_m = -totalSum / new Fraction(m + 1, 1);
                _cache.Add(b_m);
            }

            return _cache[n];
        }
    }
}
