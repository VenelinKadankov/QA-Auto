using System.Text.Json.Serialization;

namespace RestSharpAPITests;

public class CreateContact
{
    [JsonPropertyName("msg")]
    public string Message { get; set; }

    [JsonPropertyName("contact")]
    public Contact Contact { get; set; }
}
