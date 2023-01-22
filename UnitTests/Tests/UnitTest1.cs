namespace Tests;

using System.Numerics;
using UTest_NUnit;

public class Tests
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSumWithValidData()
    {
        var actual = Sumator.Sum(new int[] { 5, 6 });
        BigInteger expected = 11;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestSumWithEmptyArrThrows()
    {
        var actual = () => Sumator.Sum(Array.Empty<int>());

        Assert.That(actual, Throws.InstanceOf<IndexOutOfRangeException>()); ;
    }

    [Test]
    public void TestSumWithNegativeNumbers()
    {
        var actual = Sumator.Sum(new int[] { -6, -10 });
        BigInteger expected = -16;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestSumWithbigNumbers()
    {
        var actual = Sumator.Sum(new int[] { 2000000000, 2000000000 });
        BigInteger expected = 4000000000;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestSumWithPositiveNegativeNumbers()
    {
        var actual = Sumator.Sum(new int[] { 200, 100, -300, 1 });
        BigInteger expected = 1;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestAverageValidNumbers()
    {
        var actual = Sumator.Average(new int[] { 200, 100 });
        var expected = 150;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestAverageValidNumbersNotIntResult()
    {
        var actual = Sumator.Average(new int[] { 200, 101 });
        var expected = 150.5;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestAverageEmptyArrThrows()
    {
        var actual = () => Sumator.Average(Array.Empty<int>());

        Assert.That(actual, Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void TestAverageOneElementArray()
    {
        var actual = Sumator.Average(new int[] { 10 });
        var expected = 10;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestAverageNegativeNumbers()
    {
        var actual = Sumator.Average(new int[] { -10, -20, -30 });
        var expected = -20;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestAverageNegativeAnPositiveNumbers()
    {
        var actual = Sumator.Average(new int[] { -10, -20, 20, 50 });
        var expected = 10;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestMinimumValidData()
    {
        var actual = Sumator.MinimumValue(new int[] { 3, 5, -100, 99 });
        var expected = -100;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestMinimumEmptyData()
    {
        var actual = () => Sumator.MinimumValue(Array.Empty<int>());

        Assert.That(actual, Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void TestMinimumNullData()
    {
        var actual = () => Sumator.MinimumValue(null);

        Assert.That(actual, Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void TestMinimumSimilarData()
    {
        var actual = Sumator.MinimumValue(new int[] { 5, 5, 5, });
        var expected = 5;

        Assert.That(actual, Is.EqualTo(expected));
    }
}