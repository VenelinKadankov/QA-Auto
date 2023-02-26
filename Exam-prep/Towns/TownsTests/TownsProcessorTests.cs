using System.Reflection;
using Towns;

namespace TownsTests;

public class TownsProcessorTests
{
    private TownsProcessor _processor;

    [SetUp]
    public void SetUp()
    {
        _processor = new TownsProcessor();
    }

    [Test]
    public void Test_Ctor()
    {
        Assert.That(_processor.Towns, Is.Not.Null);
        Assert.That(_processor.Towns, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_GetResultCreateCommand()
    {
        var textCommand = "CREATE";
        var townArgs = "Burgas, Varna";
        var commandLine = textCommand + " " + townArgs;

        var createResult = _processor.ExecuteCommand(commandLine);

        Assert.That(createResult, Is.Not.Null);
        Assert.That(createResult, Is.EqualTo("Successfully created collection of towns."));
    }

    [Test]
    public void Test_GetResultCreateCommandNoArgs()
    {
        var textCommand = "CREATE";

        var createResult = _processor.ExecuteCommand(textCommand);

        Assert.That(createResult, Is.Not.Null);
        Assert.That(createResult, Is.EqualTo("Successfully created collection of towns."));
    }

    [Test]
    public void Test_GetResultPrintCommand()
    {
        var textCommand = "PRINT";

        _processor.ExecuteCommand("CREATE Sofia, Plovdiv, Varna");
        var printResult = _processor.ExecuteCommand(textCommand);

        Assert.That(printResult, Is.Not.Null);
        Assert.That(printResult, Is.EqualTo("Towns: Sofia, Plovdiv, Varna"));
    }

    [Test]
    public void Test_GetResultAddCommandNewTown()
    {
        var textCommand = "ADD Burgas";

        var addCommand = _processor.ExecuteCommand(textCommand);

        Assert.That(_processor.Towns, Is.Not.Null);
        Assert.That(_processor.Towns, Is.Not.Empty);
        Assert.That(_processor.Towns, Has.Count.EqualTo(1));
        Assert.That(addCommand, Is.EqualTo($"Successfully added: Burgas"));
    }

    [Test]
    public void Test_GetResultAddCommandExistingTown()
    {
        var textCommand = "ADD Burgas";
        _processor.ExecuteCommand(textCommand);

        var addCommand = _processor.ExecuteCommand(textCommand);

        Assert.That(_processor.Towns, Is.Not.Null);
        Assert.That(_processor.Towns, Is.Not.Empty);
        Assert.That(_processor.Towns, Has.Count.EqualTo(1));
        Assert.That(addCommand, Is.EqualTo($"Cannot add: Burgas"));
    }

    [Test]
    public void Test_GetResultRemoveValidIndex()
    {
        var textCommand = "CREATE Burgas, Veliko Tarnovo, Varna";
        _processor.ExecuteCommand(textCommand);

        var removeCommand = _processor.ExecuteCommand("REMOVE 2");

        Assert.That(_processor.Towns, Is.Not.Null);
        Assert.That(_processor.Towns, Is.Not.Empty);
        Assert.That(_processor.Towns, Has.Count.EqualTo(2));
        Assert.That(removeCommand, Is.EqualTo($"Successfully removed from index: 2"));
    }

    [Test]
    public void Test_GetResultRemoveInvalidIndex()
    {
        var textCommand = "CREATE Burgas, Veliko Tarnovo, Varna";
        _processor.ExecuteCommand(textCommand);

        var removeCommand = _processor.ExecuteCommand("REMOVE 5");

        Assert.That(_processor.Towns, Is.Not.Null);
        Assert.That(_processor.Towns, Is.Not.Empty);
        Assert.That(_processor.Towns, Has.Count.EqualTo(3));
        Assert.That(removeCommand, Is.EqualTo("Invalid operation."));
    }

    [Test]
    public void Test_GetResultReverseValidCollection()
    {
        var textCommand = "CREATE Burgas, Veliko Tarnovo, Varna";
        _processor.ExecuteCommand(textCommand);

        var reverseCommand = _processor.ExecuteCommand("REVERSE");

        Assert.That(_processor.Towns, Is.Not.Null);
        Assert.That(_processor.Towns, Is.Not.Empty);
        Assert.That(_processor.Towns, Has.Count.EqualTo(3));
        Assert.That(reverseCommand, Is.EqualTo("Collection of towns reversed."));
    }

    //[Test]
    //public void Test_GetResultReverseNullCollection()
    //{
    //    var textCommand = "CREATE  ,  ,  , ";
    //    _processor.ExecuteCommand(textCommand);

    //    FieldInfo townsField =
    //        typeof(TownsProcessor).GetField("towns", BindingFlags.NonPublic | BindingFlags.Instance);

    //    PropertyInfo propertyInfo = typeof(TownsCollection).GetProperty("Towns", BindingFlags.Public);


    //    townsField.SetValue(_processor, null);

    //    var reverseCommand = _processor.ExecuteCommand("REVERSE");

    //    Assert.That(_processor.Towns, Is.Empty);
    //    Assert.That(_processor.Towns, Has.Count.EqualTo(0));
    //    Assert.That(reverseCommand, Is.EqualTo("Cannot reverse a null collection of towns."));
    //}


    [Test]
    public void Test_GetResultReverseCollectionSingleTown()
    {
        var textCommand = "CREATE Burgas";
        _processor.ExecuteCommand(textCommand);

        var reverseCommand = _processor.ExecuteCommand("REVERSE");

        Assert.That(_processor.Towns, Has.Count.EqualTo(1));
        Assert.That(reverseCommand, Is.EqualTo("Cannot reverse a collection of towns with less than 2 items."));
    }

    [Test]
    public void Test_GetResultInvalidCommand()
    {
        var textCommand = "Burgas";
        var result = _processor.ExecuteCommand(textCommand);

        Assert.That(result, Is.EqualTo($"Invalid command: {textCommand}"));
    }
}
