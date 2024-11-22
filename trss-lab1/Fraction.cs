using System.Numerics;

namespace trss_lab1;

public class Fraction
{
    public BigInteger Numerator { get; private set; }
    public BigInteger Denominator { get; private set; }

    public static readonly Fraction Zero = new(0, 1);

    public Fraction(BigInteger numerator, BigInteger denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");

        BigInteger gcd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(numerator), BigInteger.Abs(denominator));
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;

        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

    public static Fraction operator +(Fraction a) => a;

    public static Fraction operator -(Fraction a) => new(-a.Numerator, a.Denominator);

    public static Fraction operator +(Fraction a, Fraction b) =>
        new(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

    public static Fraction operator -(Fraction a, Fraction b) =>
        new(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);

    public static Fraction operator *(Fraction a, Fraction b) =>
        new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Cannot divide by zero.");

        return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    public static Fraction operator +(Fraction a, BigInteger b) => new(a.Numerator + b * a.Denominator, a.Denominator);

    public static Fraction operator +(BigInteger b, Fraction a) => a + b;

    public static Fraction operator -(Fraction a, BigInteger b) => new(a.Numerator - b * a.Denominator, a.Denominator);

    public static Fraction operator -(BigInteger b, Fraction a) => new(b * a.Denominator - a.Numerator, a.Denominator);

    public static Fraction operator *(Fraction a, BigInteger b) => new(a.Numerator * b, a.Denominator);

    public static Fraction operator *(BigInteger b, Fraction a) => a * b;

    public static Fraction operator /(Fraction a, BigInteger b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");

        return new Fraction(a.Numerator, a.Denominator * b);
    }

    public static Fraction operator /(BigInteger b, Fraction a)
    {
        if (a.Numerator == 0)
            throw new DivideByZeroException("Cannot divide by zero.");

        return new Fraction(b * a.Denominator, a.Numerator);
    }

    public static implicit operator double(Fraction fraction) =>
        fraction.Numerator >= 0 ? Math.Exp(BigInteger.Log(fraction.Numerator) - BigInteger.Log(fraction.Denominator)) : -Math.Exp(BigInteger.Log(-fraction.Numerator) - BigInteger.Log(fraction.Denominator));

    public override string ToString() => $"{Numerator}/{Denominator}";

    public static Fraction Parse(string fractionString)
    {
        var parts = fractionString.Split('/');
        if (parts.Length != 2)
            throw new FormatException("Invalid fraction format.");

        return new Fraction(BigInteger.Parse(parts[0]), BigInteger.Parse(parts[1]));
    }

    public override bool Equals(object? obj) => obj is Fraction other && Numerator == other.Numerator && Denominator == other.Denominator;

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public static bool operator ==(Fraction a, Fraction b) => a.Equals(b);

    public static bool operator !=(Fraction a, Fraction b) => !a.Equals(b);
}
