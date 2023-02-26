using RestSharp;
using System.Net;
using System.Text.Json;

namespace RestSharpAPITests
{
    public class RestSharpAPI_Tests
    {
        private RestClient _client;
        private string _baseUrl = "https://taskboardjs.venelinkadankov.repl.co/api";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseUrl);
        }

        [Test]
        public void Test_FirstDoneTaskTitle()
        {
            var request = new RestRequest("/tasks/board/Done", Method.Get);

            var response = _client.Execute(request);

            var tasks = JsonSerializer.Deserialize<List<OwnTask>>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response, Is.Not.Null);
                Assert.That(tasks, Is.Not.Null);
                Assert.That(tasks[0].Title, Is.EqualTo("Project skeleton"));
            });
        }

        [Test]
        public void Test_FirstTaskByKeyWordIsHomePage()
        {
            var request = new RestRequest("/tasks/search/home", Method.Get);

            var response = _client.Execute(request);

            var tasks = JsonSerializer.Deserialize<List<OwnTask>>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response, Is.Not.Null);
                Assert.That(tasks, Is.Not.Null);
                Assert.That(tasks[0].Title, Is.EqualTo("Home page"));
            });
        }

        [Test]
        public void Test_FindTaskByKeyWordRandomNumEmpty()
        {
            var randNum = (new Random()).Next(0, 1000);

            var request = new RestRequest($"/tasks/search/missing{randNum}", Method.Get);

            var response = _client.Execute(request);

            var tasks = JsonSerializer.Deserialize<List<OwnTask>>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(tasks, Is.Empty);
            });
        }

        [Test]
        public void Test_TryCreateTaskInvalidData()
        {
            var request = new RestRequest($"/tasks", Method.Post);

            var body = new
            {
                description = "Empty",
            };

            request.AddBody(body);

            var response = _client.Execute(request);

            var task = JsonSerializer.Deserialize<TaskCreateError>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(task, Is.Not.Null);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(task.ErrorMessage, Is.EqualTo("Title cannot be empty!"));
            });
        }

        [Test]
        public void Test_CreateTaskValidData()
        {
            var request = new RestRequest($"/tasks", Method.Post);

            var body = new
            {
                title = "Random title",
                description = "API tests exam prep",
                board = "Open",
            };

            request.AddBody(body);

            var response = _client.Execute(request);

            var task = JsonSerializer.Deserialize<TaskCreateValid>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
                Assert.That(task.Task.Id, Is.GreaterThan(0));
                Assert.That(task.Message, Is.EqualTo("Task added."));
                Assert.That(task.Task.Title, Is.EqualTo(body.title));
                Assert.That(task.Task.Description, Is.EqualTo(body.description));
                Assert.That(task.Task.Board.Id, Is.GreaterThan(0));
                Assert.That(task.Task.Board.Name, Is.EqualTo(body.board));
                Assert.That(task.Task.DateCreated, Is.Not.Empty);
                Assert.That(task.Task.DateModified, Is.Not.Empty);
            });
        }
    }
}