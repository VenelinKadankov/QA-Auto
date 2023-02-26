using RestSharp;
using System.Net;
using System.Text.Json;

namespace RestSharpAPITests;

public class RestSharpAPI_Tests
{
    private RestClient _client;
    private string _baseUrl = "https://contactbook.venelinkadankov.repl.co/api";

    [SetUp]
    public void Setup()
    {
        _client = new RestClient(_baseUrl);
    }

    [Test]
    public void Test_FirstContactName()
    {
        var request = new RestRequest("/contacts", Method.Get);

        var response = _client.Execute(request);

        var contacts = JsonSerializer.Deserialize<List<Contact>>(response.Content);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Not.Null);
            Assert.That(contacts, Is.Not.Null);
            Assert.That(contacts[0].FirstName, Is.EqualTo("Steve"));
            Assert.That(contacts[0].LastName, Is.EqualTo("Jobs"));
        });
    }

    [Test]
    public void Test_FindContactByKeyword()
    {
        var uri = "/contacts/search/albert";
        var request = new RestRequest(uri, Method.Get);

        var response = _client.Execute(request);

        var contacts = JsonSerializer.Deserialize<List<Contact>>(response.Content);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response, Is.Not.Null);
            Assert.That(contacts, Is.Not.Null);
            Assert.That(contacts[0].FirstName, Is.EqualTo("Albert"));
            Assert.That(contacts[0].LastName, Is.EqualTo("Einstein"));
        });
    }

    [Test]
    public void Test_FindContactByKeyWordRandomNumEmpty()
    {
        var randNum = new Random().Next(0, 1000);

        var uri = $"/contacts/search/missing{randNum}";

        var request = new RestRequest(uri, Method.Get);

        var response = _client.Execute(request);

        var contacts = JsonSerializer.Deserialize<List<Contact>>(response.Content);

        Assert.Multiple(() =>
        {
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(contacts, Is.Empty);
        });
    }

    [Test]
    public void Test_TryCreateContactMissingLastName()
    {
        var request = new RestRequest($"/contacts", Method.Post);

        var body = new
        {
            firstName = "ven",
            phone = "0888888888"
        };

        request.AddBody(body);

        var response = _client.Execute(request);

        var contact = JsonSerializer.Deserialize<CreateContactError>(response.Content);

        Assert.Multiple(() =>
        {
            Assert.That(contact, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(contact.ErrorMessage, Is.EqualTo("Last name cannot be empty!"));
        });
    }

    [Test]
    public void Test_TryCreateContactMissingFirtsName()
    {
        var request = new RestRequest($"/contacts", Method.Post);

        var body = new
        {
            lastName = "ven",
            phone = "0888888888"
        };

        request.AddBody(body);

        var response = _client.Execute(request);

        var contact = JsonSerializer.Deserialize<CreateContactError>(response.Content);

        Assert.Multiple(() =>
        {
            Assert.That(contact, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(contact.ErrorMessage, Is.EqualTo("First name cannot be empty!"));
        });
    }

    // IMPORTANT: Missing functionality in API and actually creating contact with missing phone,
    // when in problem description phone is required.

    //[Test]
    //public void Test_TryCreateContactMissingPhone()
    //{
    //    var request = new RestRequest($"/contacts", Method.Post);

    //    var body = new
    //    {
    //        firstName = "ven",
    //        lastName = "kad",
    //        email = "hdhdhd@abv.bg"
    //    };

    //    request.AddBody(body);

    //    var response = _client.Execute(request);

    //    var contact = JsonSerializer.Deserialize<CreateContactError>(response.Content);

    //    Assert.Multiple(() =>
    //    {
    //        Assert.That(contact, Is.Not.Null);
    //        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    //        Assert.That(contact.ErrorMessage, Is.EqualTo("Phone cannot be empty!"));
    //    });
    //}

    [Test]
    public void Test_TryCreateContactValidData()
    {
        var request = new RestRequest($"/contacts", Method.Post);

        var body = new
        {
            firstName = "ven",
            lastName = "kad",
            email = "venkad@abv.bg",
            phone = "0888888888",
            description = "some description",
            comments = "me", 
        };

        request.AddBody(body);

        var response = _client.Execute(request);

        var contact = JsonSerializer.Deserialize<CreateContact>(response.Content);

        Assert.Multiple(() =>
        {
            Assert.That(contact, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(contact.Message, Is.EqualTo("Contact added."));
            Assert.That(contact.Contact.Id, Is.GreaterThan(0));
            Assert.That(contact.Contact.FirstName, Is.EqualTo(body.firstName));
            Assert.That(contact.Contact.LastName, Is.EqualTo(body.lastName));
            Assert.That(contact.Contact.Email, Is.EqualTo(body.email));
            Assert.That(contact.Contact.Phone, Is.EqualTo(body.phone));
            Assert.That(contact.Contact.DateCreated, Is.Not.Empty);
            Assert.That(contact.Contact.Comments, Is.EqualTo(body.comments));
        });
    }
}