using System.Text.Json.Serialization;

namespace RestSharpAPITests;

public class TaskCreateValid
{
    [JsonPropertyName("msg")]
    public string Message { get; set; }

    [JsonPropertyName("task")]
    public OwnTask Task { get; set; }
}
