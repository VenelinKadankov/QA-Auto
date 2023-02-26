using System.Text.Json.Serialization;

namespace RestSharpAPITests;

public class OwnTask
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("board")]
    public Board Board { get; set; }

    [JsonPropertyName("dateCreated")]
    public string DateCreated { get; set; }

    [JsonPropertyName("dateModified")]
    public string DateModified { get; set; }
}
