﻿using System.Numerics;

namespace trss_lab1
{
    public class Fraction
    {
        public BigInteger Numerator { get; private set; }
        public BigInteger Denominator { get; private set; }

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

        public static Fraction operator -(Fraction a) => new Fraction(-a.Numerator, a.Denominator);

        public static Fraction operator +(Fraction a, Fraction b) =>
            new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Fraction operator -(Fraction a, Fraction b) =>
            new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Fraction operator *(Fraction a, Fraction b) =>
            new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public override string ToString() => $"{Numerator}/{Denominator}";

        public static Fraction Parse(string fractionString)
        {
            var parts = fractionString.Split('/');
            if (parts.Length != 2)
                throw new FormatException("Invalid fraction format.");

            return new Fraction(BigInteger.Parse(parts[0]), BigInteger.Parse(parts[1]));
        }

        public override bool Equals(object obj) =>
            obj is Fraction other && Numerator == other.Numerator && Denominator == other.Denominator;

        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        public static bool operator ==(Fraction a, Fraction b) => a.Equals(b);

        public static bool operator !=(Fraction a, Fraction b) => !a.Equals(b);
    }
}
