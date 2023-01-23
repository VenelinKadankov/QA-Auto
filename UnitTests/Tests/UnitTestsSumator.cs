namespace Tests;

using System.Numerics;
using UTest_NUnit;

public class UnitTestsSumator
{
    [Test]
    public void TestSumWithPositiveNumbersData()
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
    public void TestSumWithBigNumbers()
    {
        var actual = Sumator.Sum(new int[] { 2000000000, 2000000000 });
        BigInteger expected = 4000000000;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestSumWithPositiveAndNegativeNumbers()
    {
        var actual = Sumator.Sum(new int[] { 200, 100, -300, 1 });
        BigInteger expected = 1;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestAverageWithPositiveNumbers()
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
    public void TestAverageWithEmptyArrayThrows()
    {
        var actual = () => Sumator.Average(Array.Empty<int>());

        Assert.That(actual, Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void TestAverageWithOneElementArray()
    {
        var actual = Sumator.Average(new int[] { 10 });
        var expected = 10;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestAverageWithNegativeNumbers()
    {
        var actual = Sumator.Average(new int[] { -10, -20, -30 });
        var expected = -20;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestAverageWithNegativeAndPositiveNumbers()
    {
        var actual = Sumator.Average(new int[] { -10, -20, 20, 50 });
        var expected = 10;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestMinimumWithValidArray()
    {
        var actual = Sumator.MinimumValue(new int[] { 3, 5, -100, 99 });
        var expected = -100;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestMinimumWithEmptyArrayThrows()
    {
        var actual = () => Sumator.MinimumValue(Array.Empty<int>());

        Assert.That(actual, Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void TestMinimumWithNullForArrayThrows()
    {
        var actual = () => Sumator.MinimumValue(null);

        Assert.That(actual, Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void TestMinimumWithSimilarData()
    {
        var actual = Sumator.MinimumValue(new int[] { 5, 5, 5, });
        var expected = 5;

        Assert.That(actual, Is.EqualTo(expected));
    }
}