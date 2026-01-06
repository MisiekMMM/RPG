using System.Text.Json.Serialization;
using RPG;

public class Wybor
{
    [JsonPropertyName("pytanie")]
    public string pytanie { get; set; } = "";
    [JsonPropertyName("opcje")]
    public List<string> Opcje { get; set; } = new();
}