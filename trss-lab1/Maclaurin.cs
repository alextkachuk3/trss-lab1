namespace trss_lab1;

public class Maclaurin
{
    public static double Cotangent(double x, double epsilon)
    {
        if (x == 0.0 || Math.Abs(x) >= Math.PI)
            throw new ArgumentException("x must be in the range (0, π) and not equal 0.");

        double sum = 0.0;
        int n = 0;
        double prevSum = 0.0;

        while (true)
        {
            double term = Math.Pow(-4.0, n) * Utility.ReversedFactorial(2 * n) * (double)Bernoulli.Evaluate(2 * n) * Math.Pow(x, (2 * n) - 1);
            sum += term;

            if (Math.Abs(sum - prevSum) < epsilon)
            {
                double q = Math.Pow(-4.0, n) * Utility.ReversedFactorial(2 * n) * (double)Bernoulli.Evaluate(2 * n) * Math.Pow(x, (2 * n) - 1);
                break;
            }

            prevSum = sum;
            n++;
        }

        return sum;
    }
}
