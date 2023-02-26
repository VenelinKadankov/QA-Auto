using System.Text.Json.Serialization;

namespace RestSharpAPITests;

public class CreateContactError
{
    [JsonPropertyName("errMsg")]
    public string ErrorMessage { get; set; }
}
