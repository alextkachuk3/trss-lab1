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
    }

}