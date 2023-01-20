using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CommonLibrary.Models;

public class ToDoItem
{
    [JsonPropertyName("id")]
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }
    [JsonPropertyName("description")]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }
    [JsonPropertyName("isComplete")]
    [JsonProperty(PropertyName = "isComplete")]
    public bool IsComplete { get; set; }
    [JsonPropertyName("dateCreated")]
    [JsonProperty(PropertyName = "dateCreated")]
    public DateTime DateCreated { get; set; }
}