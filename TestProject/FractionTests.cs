using System.Numerics;
using trss_lab1;

namespace TestProject
{

    [TestClass]
    public class FractionTests
    {
        [TestMethod]
        public void ConstructorShouldSimplifyFraction()
        {
            var fraction = new Fraction(10, 20);
            Assert.AreEqual(new Fraction(1, 2), fraction, "Fraction should be simplified to 1/2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorShouldThrowExceptionForZeroDenominator()
        {
            new Fraction(1, 0);
        }

        [TestMethod]
        public void AdditionOperatorShouldAddFractions()
        {
            var fraction1 = new Fraction(1, 2);
            var fraction2 = new Fraction(1, 3);
            var result = fraction1 + fraction2;
            Assert.AreEqual(new Fraction(5, 6), result, "1/2 + 1/3 should equal 5/6");
        }

        [TestMethod]
        public void SubtractionOperatorShouldSubtractFractions()
        {
            var fraction1 = new Fraction(3, 4);
            var fraction2 = new Fraction(1, 4);
            var result = fraction1 - fraction2;
            Assert.AreEqual(new Fraction(1, 2), result, "3/4 - 1/4 should equal 1/2");
        }

        [TestMethod]
        public void MultiplicationOperatorShouldMultiplyFractions()
        {
            var fraction1 = new Fraction(2, 3);
            var fraction2 = new Fraction(3, 4);
            var result = fraction1 * fraction2;
            Assert.AreEqual(new Fraction(1, 2), result, "2/3 * 3/4 should equal 1/2");
        }

        [TestMethod]
        public void DivisionOperatorShouldDivideFractions()
        {
            var fraction1 = new Fraction(3, 4);
            var fraction2 = new Fraction(2, 5);
            var result = fraction1 / fraction2;
            Assert.AreEqual(new Fraction(15, 8), result, "3/4 / 2/5 should equal 15/8");
        }

        [TestMethod]
        public void UnaryPlusOperatorShouldReturnSameFraction()
        {
            var fraction = new Fraction(3, 4);
            var result = +fraction;
            Assert.AreEqual(fraction, result, "+3/4 should equal 3/4");
        }

        [TestMethod]
        public void UnaryMinusOperatorShouldNegateFraction()
        {
            var fraction = new Fraction(3, 4);
            var result = -fraction;
            Assert.AreEqual(new Fraction(-3, 4), result, "-3/4 should equal -3/4");
        }

        [TestMethod]
        public void EqualityOperatorShouldReturnTrueForEqualFractions()
        {
            var fraction1 = new Fraction(3, 4);
            var fraction2 = new Fraction(6, 8);
            Assert.IsTrue(fraction1 == fraction2, "3/4 should be equal to 6/8");
        }

        [TestMethod]
        public void InequalityOperatorShouldReturnTrueForUnequalFractions()
        {
            var fraction1 = new Fraction(3, 4);
            var fraction2 = new Fraction(2, 3);
            Assert.IsTrue(fraction1 != fraction2, "3/4 should not be equal to 2/3");
        }

        [TestMethod]
        public void ToStringShouldReturnCorrectStringRepresentation()
        {
            var fraction = new Fraction(3, 4);
            Assert.AreEqual("3/4", fraction.ToString(), "Fraction should be represented as '3/4'");
        }

        [TestMethod]
        public void ParseShouldParseFractionFromString()
        {
            var fraction = Fraction.Parse("5/6");
            Assert.AreEqual(new Fraction(5, 6), fraction, "Fraction should be parsed as 5/6");
        }

        [TestMethod]
        public void TestFractionPlusBigInteger()
        {
            var fraction = new Fraction(new BigInteger(3), new BigInteger(4));
            var bigInt = new BigInteger(5);
            var result = fraction + bigInt;

            Assert.AreEqual("23/4", result.ToString());
        }

        [TestMethod]
        public void TestBigIntegerPlusFraction()
        {
            var fraction = new Fraction(new BigInteger(3), new BigInteger(4));
            var bigInt = new BigInteger(5);
            var result = bigInt + fraction;

            Assert.AreEqual("23/4", result.ToString());
        }

        [TestMethod]
        public void TestFractionMinusBigInteger()
        {
            var fraction = new Fraction(new BigInteger(3), new BigInteger(4));
            var bigInt = new BigInteger(5);
            var result = fraction - bigInt;

            Assert.AreEqual("-17/4", result.ToString());
        }

        [TestMethod]
        public void TestBigIntegerMinusFraction()
        {
            var fraction = new Fraction(new BigInteger(3), new BigInteger(4));
            var bigInt = new BigInteger(5);
            var result = bigInt - fraction;

            Assert.AreEqual("17/4", result.ToString());
        }

        [TestMethod]
        public void TestFractionTimesBigInteger()
        {
            var fraction = new Fraction(new BigInteger(3), new BigInteger(4));
            var bigInt = new BigInteger(5);
            var result = fraction * bigInt;

            Assert.AreEqual("15/4", result.ToString());
        }

        [TestMethod]
        public void TestBigIntegerTimesFraction()
        {
            var fraction = new Fraction(new BigInteger(3), new BigInteger(4));
            var bigInt = new BigInteger(5);
            var result = bigInt * fraction;

            Assert.AreEqual("15/4", result.ToString());
        }

        [TestMethod]
        public void TestFractionDividedByBigInteger()
        {
            var fraction = new Fraction(new BigInteger(3), new BigInteger(4));
            var bigInt = new BigInteger(5);
            var result = fraction / bigInt;

            Assert.AreEqual("3/20", result.ToString());
        }

        [TestMethod]
        public void TestBigIntegerDividedByFraction()
        {
            var fraction = new Fraction(new BigInteger(3), new BigInteger(4));
            var bigInt = new BigInteger(5);
            var result = bigInt / fraction;

            Assert.AreEqual("20/3", result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestFractionDividedByZeroBigInteger()
        {
            var fraction = new Fraction(new BigInteger(3), new BigInteger(4));
            var bigInt = new BigInteger(0);
            _ = fraction / bigInt;
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestBigIntegerDividedByZeroFraction()
        {
            var fraction = new Fraction(new BigInteger(0), new BigInteger(4));
            var bigInt = new BigInteger(5);
            _ = bigInt / fraction;
        }
    }
}
