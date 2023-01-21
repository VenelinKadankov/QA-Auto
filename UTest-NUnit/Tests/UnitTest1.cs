using UTest_NUnit;

namespace Tests;

public class Tests
{
    private Sumator sumator;

    [SetUp]
    public void Setup()
    {
        this.sumator = new Sumator();
    }

    [Test]
    public void TestSumWithValidData()
    {
        Assert.That(this.sumator.Sum(new int[] { 5, 6 }), Is.EqualTo(11));
    }

    [Test]
    public void TestSumWithEmptyArrThrows()
    {
        Assert.That(() => this.sumator.Sum(Array.Empty<int>()), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void TestSumWithNegativeNumbers()
    {
        Assert.That(this.sumator.Sum(new int[] { -6, -10 }), Is.EqualTo(-16));
    }

    [Test]
    public void TestSumWithbigNumbers()
    {
        Assert.That(this.sumator.Sum(new int[] { 2000000000, 147483647 }), Is.EqualTo(2147483647));
    }

    [Test]
    public void TestSumWithPositiveNegativeNumbers()
    {
        Assert.That(this.sumator.Sum(new int[] { 200, 100, -300, 1 }), Is.EqualTo(1));
    }

    [Test]
    public void TestAverageValidNumbers()
    {
        Assert.That(this.sumator.Average(new int[] { 200, 100 }), Is.EqualTo(150));
    }

    [Test]
    public void TestAverageValidNumbersNotIntResult()
    {
        Assert.That(this.sumator.Average(new int[] { 200, 101 }), Is.EqualTo(150.5));
    }

    [Test]
    public void TestAverageEmptyArrThrows()
    {
        Assert.That(() => this.sumator.Average(Array.Empty<int>()), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void TestAverageOneElementArray()
    {
        Assert.That(this.sumator.Average(new int[] { 10 }), Is.EqualTo(10));
    }

    [Test]
    public void TestAverageNegativeNumbers()
    {
        Assert.That(this.sumator.Average(new int[] { -10, -20, -30 }), Is.EqualTo(-20));
    }

    [Test]
    public void TestAverageNegativeAnPositiveNumbers()
    {
        Assert.That(this.sumator.Average(new int[] { -10, -20, 20, 50 }), Is.EqualTo(10));
    }
    //[Test]
    //public void Test_SumTwoNumbers()
    //{
    //    Assert.DoesNotThrow(() => this.sumator.Test_SumTwoNumbers());
    //}

    //[Test]
    //public void Test_SumEmptyArray()
    //{
    //    Assert.That(() => this.sumator.Test_SumEmptyArray(), Throws.InstanceOf<Exception>());
    //}
}