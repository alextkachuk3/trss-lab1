﻿using System.Numerics;

namespace trss_lab1;

public class Utility
{
    public static BigInteger BinomialCoefficient(int n, int k)
    {
        if (k < 0 || k > n)
            return 0;
        if (k == 0 || k == n)
            return 1;

        BigInteger result = 1;
        for (int i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }

        return result;
    }

    public static double Factorial(int n)
    {
        double result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public static double ReversedFactorial(int n)
    {
        double result = 1;
        for(int i = 1; i <= n; i++)
        {
            result /= i;
        }
        return result;
    }
}
