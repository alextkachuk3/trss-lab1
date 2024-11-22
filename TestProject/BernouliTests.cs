using System.Numerics;
using trss_lab1;

namespace TestProject;

[TestClass]
public class BernoulliTests
{
    [TestMethod]
    public void TestMin()
    {
        int n = 0;
        var result = Bernoulli.Evaluate(n);

        var expected = new Fraction(new BigInteger(1), new BigInteger(1));
        Assert.AreEqual(expected.ToString(), result.ToString());
    }

    [TestMethod]
    public void TestBig()
    {
        int n = 100;
        var result = Bernoulli.Evaluate(n);

        var expected = new Fraction(
            BigInteger.Parse("-94598037819122125295227433069493721872702841533066936133385696204311395415197247711"),
            new BigInteger(33330)
        );
        Assert.AreEqual(expected.ToString(), result.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestOutOfRange()
    {
        int n = new Random().Next(-100, 0);
        Bernoulli.Evaluate(n);
    }

    [TestMethod]
    public void TestMiddle()
    {
        int n = 50;
        var result = Bernoulli.Evaluate(n);

        var expected = new Fraction(BigInteger.Parse("495057205241079648212477525"), new BigInteger(66));
        Assert.AreEqual(expected.ToString(), result.ToString());
    }

    [TestMethod]
    public void TestOdd()
    {
        int n = new Random().Next(1, 50) * 2 + 1;
        var result = Bernoulli.Evaluate(n);

        var expected = new Fraction(BigInteger.Zero, new BigInteger(1));
        Assert.AreEqual(expected.ToString(), result.ToString());
    }

    [TestMethod]
    public void TestCache()
    {
        int n = 100;
        var result = Bernoulli.Evaluate(n);
        var expected100 = new Fraction(
            BigInteger.Parse("-94598037819122125295227433069493721872702841533066936133385696204311395415197247711"),
            new BigInteger(33330)
        );
        Assert.AreEqual(expected100.ToString(), result.ToString());

        n = 50;
        result = Bernoulli.Evaluate(n);
        var expected50 = new Fraction(BigInteger.Parse("495057205241079648212477525"), new BigInteger(66));
        Assert.AreEqual(expected50.ToString(), result.ToString());
    }
}
