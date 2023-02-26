using Lift;

namespace LiftTests;

public class LiftTests
{
    private LiftSimulator _liftSimulator;

    [SetUp]
    public void SetUp()
    {
        _liftSimulator = new LiftSimulator();
    }

    [Test]
    public void Test_NulOrEmptyLiftStateThrows()
    {
        Assert.That(() => _liftSimulator.FitPeopleOnTheLift(100, null),
            Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Invalid lift size. It should have positive number of cabins"));

        Assert.That(() => _liftSimulator.FitPeopleOnTheLift(100, new int[0]),
            Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Invalid lift size. It should have positive number of cabins"));
    }

    [Test]
    public void Test_NegativeLiftStateThrows()
    {
        Assert.That(() => _liftSimulator.FitPeopleOnTheLift(100, new int[] { 1, -1, 0, 2 }),
            Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Invalid lift seat: -1"));
    }

    [Test]
    public void Test_LargerThanLimitLiftStateThrows()
    {
        Assert.That(() => _liftSimulator.FitPeopleOnTheLift(100, new int[] { 2, 1, 5, 0 }),
            Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Invalid lift seat: 5"));
    }

    [Test]
    public void Test_PeopleCountZeroOrNegativeNumThrows()
    {
        Assert.That(() => _liftSimulator.FitPeopleOnTheLift(-5, new int[] { 2, 1, 0, 0 }),
            Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("People waiting should be > 0"));

        Assert.That(() => _liftSimulator.FitPeopleOnTheLift(0, new int[] { 2, 1, 0, 0 }),
            Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("People waiting should be > 0"));
    }

    [Test]
    public void Test_WhenPeopleAreSeatedProgramEnds()
    {
        var inputLiftState = new int[] { 0, 0 };
        var result = _liftSimulator.FitPeopleOnTheLift(7, inputLiftState);

        Assert.That(string.Join(", ", result), Is.EqualTo("4, 3"));
        Assert.That(result, Is.EqualTo(new int[] {4, 3}));
    }

    [Test]
    public void Test_FitPeopleGetResultPeopleCountBiggerThanSeatsCount()
    {
        var inputLiftState = new int[] { 0, 0 };
        var result = _liftSimulator.FitPeopleOnTheLiftAndGetResult(10, inputLiftState);

        Assert.That(result, Is.EqualTo($"There isn't enough space! 2 people in a queue!{Environment.NewLine}4 4"));
    }

    [Test]
    public void Test_FitPeopleGetResultPeopleCountEqualWtihSeatsCount()
    {
        var inputLiftState = new int[] { 0, 0 };
        var result = _liftSimulator.FitPeopleOnTheLiftAndGetResult(8, inputLiftState);

        // TODO: $"All people placed and the lift is full.{Environment.NewLine}4 4"
        Assert.That(result, Is.EqualTo($"All people placed and the lift if full.{Environment.NewLine}4 4"));
    }

    [Test]
    public void Test_FitPeopleGetResultPeopleCountSmallerThanSeatsCount()
    {
        var inputLiftState = new int[] { 0, 0, 0 };
        var result = _liftSimulator.FitPeopleOnTheLiftAndGetResult(5, inputLiftState);

        Assert.That(result, Is.EqualTo($"The lift has 7 empty spots!{Environment.NewLine}4 1 0"));
    }

}