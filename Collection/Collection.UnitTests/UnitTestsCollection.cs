namespace Collection.UnitTests;

public class UnitTestsCollection
{
    private Collection<int> _intCollection;
    private Collection<string> _stringCollection;

    [SetUp]
    public void Setup()
    {
        _intCollection = new Collection<int>();
        _stringCollection = new Collection<string>();
    }

    [Test]
    public void Test_Collection_CreatonWithArray()
    {
        var collection = new Collection<int>(2, 4, 5, 9);

        Assert.Multiple(() =>
        {
            Assert.That(collection.Count, Is.EqualTo(4));
            Assert.That(collection.Capacity, Is.EqualTo(16));
        });
    }


    [Test]
    public void Test_Collection_Count()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_intCollection, Is.Empty);
            Assert.That(_stringCollection, Is.Empty);
        });
    }

    [Test]
    public void Test_Collection_Capacity()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_intCollection.Capacity, Is.EqualTo(16));
            Assert.That(_stringCollection.Capacity, Is.EqualTo(16));
        });
    }

    [Test]
    public void Test_Collection_AddBeforeReachingLimit()
    {
        _intCollection.Add(1);
        _stringCollection.Add("1");

        Assert.Multiple(() =>
        {
            Assert.That(_intCollection.Count, Is.EqualTo(1));
            Assert.That(_stringCollection.Count, Is.EqualTo(1));
            Assert.That(_intCollection.Capacity, Is.EqualTo(16));
            Assert.That(_stringCollection.Capacity, Is.EqualTo(16));
        });
    }

    [Test]
    public void Test_Collection_AddAfterLimit()
    {
        for (int i = 0; i < 16; i++)
        {
            _intCollection.Add(i);
            _stringCollection.Add($"{i}");
        }

        _intCollection.Add(1);
        _stringCollection.Add("1");

        Assert.Multiple(() =>
        {
            Assert.That(_intCollection.Count, Is.EqualTo(17));
            Assert.That(_stringCollection.Count, Is.EqualTo(17));
            Assert.That(_intCollection.Capacity, Is.EqualTo(32));
            Assert.That(_stringCollection.Capacity, Is.EqualTo(32));
        });
    }

    [Test]
    public void Test_Collection_AddRangeBeforeReachingLimit()
    {
        _intCollection.AddRange(1, 2);
        _stringCollection.AddRange("1", "2");

        Assert.Multiple(() =>
        {
            Assert.That(_intCollection.Count, Is.EqualTo(2));
            Assert.That(_stringCollection.Count, Is.EqualTo(2));
            Assert.That(_intCollection.Capacity, Is.EqualTo(16));
            Assert.That(_stringCollection.Capacity, Is.EqualTo(16));
        });
    }
}