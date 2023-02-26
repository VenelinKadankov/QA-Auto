using System.Text.Json.Serialization;

namespace RestSharpAPITests;

public class TaskCreateError
{
    [JsonPropertyName("errMsg")]
    public string ErrorMessage { get; set; }
}
