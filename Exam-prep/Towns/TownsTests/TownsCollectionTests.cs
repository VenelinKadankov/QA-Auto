namespace TownsTests;

public class TownsCollectionTests
{
    private TownsCollection _emptyCollection;
    private TownsCollection _collection;

    [SetUp]
    public void SetUp()
    {
        _emptyCollection = new TownsCollection();
        _collection = new TownsCollection("Burgas, Varna, Istanbul");
    }

    [Test]
    public void Test_TownsCollectionCtors()
    {
        Assert.That(_emptyCollection, Is.Not.Null);
        Assert.That(_emptyCollection.Towns.Count, Is.EqualTo(0));

        Assert.That(_collection, Is.Not.Null);
        Assert.That(_collection.Towns.Count, Is.EqualTo(3));
    }

    [Test]
    public void Test_ToStringMethod()
    {
        var towns = _collection.ToString();

        Assert.That(towns, Is.Not.Null);
        Assert.That(towns, Is.EqualTo("Burgas, Varna, Istanbul"));
    }

    [Test]
    public void Test_AddNulOrEmptyTown()
    {
        var isAddedEmpty = _collection.Add("");
        var isAddedNull = _collection.Add(null);

        Assert.That(isAddedEmpty, Is.False);
        Assert.That(isAddedNull, Is.False);
        Assert.That(_collection.Towns, Has.Count.EqualTo(3));
    }

    [Test]
    public void Test_AddExistingTown()
    {
        var isAdded = _collection.Add("Burgas");

        Assert.That(isAdded, Is.False);
        Assert.That(_collection.Towns, Has.Count.EqualTo(3));
    }

    [Test]
    public void Test_AddNewTown()
    {
        var isAdded = _collection.Add("Sofia");

        Assert.That(isAdded, Is.True);
        Assert.That(_collection.Towns, Has.Count.EqualTo(4));
    }

    [Test]
    public void Test_RemoveInvalidIndex()
    {
        Assert.That(() => _collection.RemoveAt(5),
            Throws.InstanceOf<ArgumentOutOfRangeException>());
        Assert.That(() => _collection.RemoveAt(-5),
            Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void Test_RemoveValidIndex()
    {
        _collection.RemoveAt(1);
        Assert.That(_collection.Towns, Has.Count.EqualTo(2));
    }

    [Test]
    public void Test_ReverseEmptyCollection()
    {
        var towns = new TownsCollection();
        towns.Towns = null;

        Assert.That(() => towns.Reverse(), Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Test_ReverseCollectionOneTown()
    {
        _emptyCollection.Add("Burgas");

        Assert.That(() => _emptyCollection.Reverse(), Throws.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ReverseCollection()
    {
        _collection.Reverse();

        Assert.That(_collection.ToString(), Is.EqualTo("Istanbul, Varna, Burgas"));
    }
}
